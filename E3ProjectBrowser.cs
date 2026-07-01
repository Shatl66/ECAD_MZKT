using e3;
using E3SetAdditionalPart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3_WGM
{
    public partial class E3ProjectBrowser : UserControl
    {
        public E3ProjectBrowser()
        {
            InitializeComponent();
        }


        public void RefreshData(E3Assembly umens_e3projec)
        {
            textBoxNameIzdWindchill.Text = E3WGMForm.UtilsInstance.nameContainerWindchill;

        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUploadProjectDoc_Click(object sender, EventArgs e)
        {
            e3Job job = E3WGMForm.UtilsInstance.ConnectToE3Series(); // нужен только job
            String tempPath = E3WGMForm.UtilsInstance.tempPathForDoc;
            String prjFileName = job.GetName() + ".e3s"; // E3WGMForm.UtilsInstance.umens_e3project.number + ".e3s";

            E3Documentation prjDocument = new E3Documentation(E3WGMForm.public_umens_e3project, // любую Assembly, ее не используем для выгрузки
                                                                    job.GetName(), // тут обозначение СЧ
                                                                    "Проект ECAD", // из ТЗ
                                                                    job,
                                                                    prjFileName,
                                                                    "E3ProjectDoc", // признак, что создаем E3ProjectDoc
                                                                    tempPath); //TODO не используем


            prjDocument.nameContainer = E3WGMForm.UtilsInstance.nameContainerWindchill;
            prjDocument.folder = "/Default/Конструкторская документация"; // /Default/Design/

            // 1. создаем WTDocument проекта Е3 в Windchill если его там еще нет
            string jsonDocumentationFromWindchill = "";

                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.UseSimpleDictionaryFormat = true;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(E3Documentation), settings);
                ser.WriteObject(stream, prjDocument);
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                string jsonDocumentation = sr.ReadToEnd();                
                jsonDocumentation = "{\"__type\":\"E3Documentation:#E3_WGM\"," + jsonDocumentation.Substring(1);

                try
                {
                    jsonDocumentationFromWindchill = E3WGMForm.wchHTTPClient.getJSON(jsonDocumentation, "netmarkets/jsp/by/iba/e3/http/createE3Documentation.jsp");
                }
                catch (Exception ex)
                {
                    UmensLogger.Log($"Создание документа Е3 проект в Windchill. Сообщение Windchill: {ex.Message}");
                    return;
                }

                MemoryStream stream2 = new MemoryStream(Encoding.UTF8.GetBytes(jsonDocumentationFromWindchill));
                DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(E3Documentation), settings);
                E3Documentation wchDoc = (E3Documentation)ser2.ReadObject(stream2);
                prjDocument.updateDoc(wchDoc);


            // 2.выгружаем файл проекта Е3 на локальный диск пользователя в папку заданную в конфиг.файле windchillserver.json
             
            job.SaveAs( Path.Combine(tempPath, prjFileName)); // сохраняем изменения в локальном файле или  выгружаем multyuser файл

            // 3. передаем файл в Windchill где он будет привязан к документу как содержимое
            MemoryStream stream3 = new MemoryStream();
            DataContractJsonSerializerSettings settings3 = new DataContractJsonSerializerSettings();
            settings3.UseSimpleDictionaryFormat = true;
            DataContractJsonSerializer ser3 = new DataContractJsonSerializer(typeof(E3Documentation), settings3);
            ser3.WriteObject(stream3, prjDocument);
            stream3.Position = 0;
            StreamReader sr3 = new StreamReader(stream3);
            string jsonE3Doc = sr3.ReadToEnd();
            jsonE3Doc = "{\"__type\":\"E3Documentation:#E3_WGM\"," + jsonE3Doc.Substring(1);
            try
            {
                E3WGMForm.wchHTTPClient.updateE3DocumentationContent(jsonE3Doc, "netmarkets/jsp/by/iba/e3/http/updateE3DocumentationContent.jsp", prjDocument.filePath, prjDocument.fileName);
            }
            catch (Exception ex)
            {
                UmensLogger.Log($"Замена содержимого проекта Е3 в Windchill. Сообщение Windchill: {ex.Message}");
                return;
            }


            UmensLogger.Log($"Выгрузка проекта Е3 {prjDocument.number} в Windchill завершена");

            E3WGMForm.UtilsInstance.DisconnectFromE3Series();
        }
    }
}

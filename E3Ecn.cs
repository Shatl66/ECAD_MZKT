using System.Runtime.Serialization;

namespace E3_WGM
{
    [DataContract]
    public class E3Ecn
    {
        [DataMember(Name = "_revisionECN")]
        public string Revision { get; set; } = "";

        [DataMember(Name = "_dateECN")]
        public string DateEcn { get; set; } = "";

        [DataMember(Name = "_resultECN")]
        public string Result { get; set; } = "";

        [DataMember(Name = "_numberECN")]
        public string NumberEcn { get; set; } = "";

        [DataMember(Name = "_signECN")]
        public string Sign { get; set; } = "";

        public E3Ecn() { }
    }
}

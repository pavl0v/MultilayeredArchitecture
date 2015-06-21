using System.Runtime.Serialization;

namespace WcfServiceLayer.Contracts
{
    [DataContract(Name = "ResponseOfType{0}")]
    public class Response<T>
    {
        private T result = default(T);
        [DataMember]
        public T Result
        {
            get { return result; }
            set { result = value; }
        }

        private string message = "";
        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private string method = "";
        [DataMember]
        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        private bool isSuccessful = false;
        [DataMember]
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public Response(string method)
        {
            this.isSuccessful = false;
            this.message = "";
            this.method = method;
            this.result = default(T);
        }
    }
}
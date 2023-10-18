namespace MicroUniverso.AprovacaoNotasCompra.Application.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AnswerAttribute : Attribute
    {
        private string _value;
        public AnswerAttribute(string value)
        {
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }
}
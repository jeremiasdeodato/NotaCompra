using MicroUniverso.AprovacaoNotasCompra.Application.Core.Attributes;
using System.ComponentModel;
using System.Reflection;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Core.Extensions
{
    public static class EnumExtensions
    {

        public static string? GetSafeEnumAnswer<T>(T enumValue)
        {
            if (enumValue == null)
            {
                return null;
            }

            return (enumValue as Enum).GetEnumAnswer();
        }

        public static string GetEnumAnswer(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString())!;

            if (fi == null)
                return string.Empty;

            var attributes = fi.GetCustomAttributes(typeof(AnswerAttribute), false) as AnswerAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Value;
            }

            return value.ToString();
        }
    }
}
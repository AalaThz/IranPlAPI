using Ganss.Xss;

namespace Iranpl.ApplicationCore.Security
{
    public static class XssSecurity
    {
        public static string CheckText(this string text)
        {
            var htmlSanitizer = new HtmlSanitizer();
            htmlSanitizer.KeepChildNodes = true;
            htmlSanitizer.AllowDataAttributes = true;

            return htmlSanitizer.Sanitize(text);
        }
    }
}

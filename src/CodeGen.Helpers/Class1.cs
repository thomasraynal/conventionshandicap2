using CodegenUP.CustomHandlebars;
using CodegenUP;
using HandlebarsDotNet;
using System.Text;

namespace CodeGen.Helpers
{
    public class OneLine2 : SimpleBlockHelperBase<object, int?, bool?>
    {

        public OneLine2() : base("one_line2") { }

        public override void HelperFunction(TextWriter output, HelperOptions options, object context, int? indent, bool? lineBreak, object[] otherArguments)
        {
            EnsureArgumentsCountMax(otherArguments, 0);

            using var stream = new MemoryStream();
            using (var tw = new StreamWriter(stream, Encoding.Default, 500, true))
            {
                options.Template(tw, context);
            }
            stream.Seek(0, SeekOrigin.Begin);

            using var tr = new StreamReader(stream);
            var result = tr.ReadToEnd();
            result = StringHelpers.OnOneLine(result, indent, lineBreak);
            output.WriteSafeString(result);
        }


    }
}   
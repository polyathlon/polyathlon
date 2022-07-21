using DevExpress.Utils;
using System.IO;

namespace Polyathlon.Helpers {
    public class MailMergeTemplatesHelper {
        static string[] templateNames = new string[] { "Employee of the Month.snx", "Employee Probation Notice.snx", "Employee Service Excellence.snx", "Employee Thank You Note.snx", "Welcome to DevAV.snx" };
        public static List<TemplateViewModel> GetAllTemplates() {
            List<TemplateViewModel> templates = new List<TemplateViewModel>();
            foreach (var name in templateNames) {
                Stream stream = GetTemplateStream(name);
                templates.Add(new TemplateViewModel() { Name = name.Replace(".snx", ""), });
            }
            return templates;
        }

        public static Stream GetTemplateStream(string templateName) {
            return AssemblyHelper.GetEmbeddedResourceStream(typeof(MailMergeTemplatesHelper).Assembly, templateName, false);
        }
    }

    public class TemplateViewModel {
        public string Name { get; set; }
        public Stream Template {
            get {
                return MailMergeTemplatesHelper.GetTemplateStream(Name + ".snx");
            }
        }
    }
}

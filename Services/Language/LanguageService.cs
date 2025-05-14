using System.Globalization;
using System.Text.Json;

namespace Portifolio_Blazor.Services.Language
{
    public interface ILanguageService
    {
        string GetLabels(string key);
        string GetMessages(string key);
        Task<bool> ChangeLanguage(CultureInfo culture);
        bool SetupChangeLanguage(string culture);
    }

    public class LanguageService : ILanguageService
    {
        private IDictionary<string, string> labels { get; set; }
        private IDictionary<string, string> messages { get; set; }

        public string GetLabels(string key)
        {
            string result = string.Empty;

            try
            {
                if (labels == null)
                    Setup();

                if (labels != null && labels.Keys.Count > 0)
                    result = labels.Where(x => x.Key == key).FirstOrDefault().Value.ToString();
            }
            catch (Exception)
            {
                result = key;
            }

            return result;
        }
        private void Setup()
        {
            try
            {
                #region Labels
                string localLabels = string.Empty;
                switch (CultureInfo.CurrentCulture.ToString().ToLower())
                {
                    case "en-us":
                        localLabels = L_EN_US.label;
                        break;
                    case "es-es":
                        localLabels = L_ES_ES.label;
                        break;
                    case "pt-br":
                        localLabels = L_PT_BR.label;
                        break;
                }
                labels = JsonSerializer.Deserialize<IDictionary<string, string>>(localLabels);
                #endregion

                #region Messages
                string localMessages = string.Empty;
                switch (CultureInfo.CurrentCulture.ToString().ToLower())
                {
                    case "en-us":
                        localMessages = M_EN_US.messages;
                        break;
                    case "es-es":
                        localMessages = M_ES_ES.messages;
                        break;
                    case "pt-br":
                        localMessages = M_PT_BR.messages;
                        break;
                }
                messages = JsonSerializer.Deserialize<IDictionary<string, string>>(localMessages);
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Setup(string culture)
        {
            try
            {
                #region Labels
                string localLabels = string.Empty;
                switch (culture.ToLower())
                {
                    case "en-us":
                        localLabels = L_EN_US.label;
                        break;
                    case "es-es":
                        localLabels = L_ES_ES.label;
                        break;
                    case "pt-br":
                        localLabels = L_PT_BR.label;
                        break;
                }
                labels = JsonSerializer.Deserialize<IDictionary<string, string>>(localLabels);
                #endregion

                #region Messages
                string localMessages = string.Empty;
                switch (culture.ToLower())
                {
                    case "en-us":
                        localMessages = M_EN_US.messages;
                        break;
                    case "es-es":
                        localMessages = M_ES_ES.messages;
                        break;
                    case "pt-br":
                        localMessages = M_PT_BR.messages;
                        break;
                }
                messages = JsonSerializer.Deserialize<IDictionary<string, string>>(localMessages);
                #endregion
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string GetMessages(string key)
        {
            string result = string.Empty;

            try
            {
                if (messages != null && messages.Keys.Count > 0)
                    result = messages.Where(x => x.Key == key).FirstOrDefault().Value.ToString();
            }
            catch (Exception)
            {
                result = key;
            }

            return result;
        }
        public async Task<bool> ChangeLanguage(CultureInfo culture)
        {
            try
            {
                CultureInfo.CurrentCulture = culture;
                Setup();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool SetupChangeLanguage(string culture)
        {
            try
            {
                Setup(culture.ToLower());
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}

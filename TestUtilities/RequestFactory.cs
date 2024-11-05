using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SITS_Test_Automation.Domain.Interfaces;
using SITS_Test_Automation.Domain.Models.Request;

namespace SITS_Test_Automation.TestUtilities
{
    public static class RequestFactory
    {
        public static DueInRequest CreateDueInRequest()
        {
            return new DueInRequest
            {
                locale_code = "fr-FR",
                object_type = new List<string>(),
                due_in = new List<string> { "Overdue" },
                status = new List<string>(),
                category = new List<string>(),
                supportLocaleStatus = new List<string>(),
                sort = string.Empty
            };
        }

        public static NavigateToEditRequest CreateNavigateToEditRequest(string textId)
        {
            return new NavigateToEditRequest
            {
                textid = textId,
                source_locale_code = "en-ZZ",
                target_locale_code = "fr-FR",
                object_type_short = "METY",
                isParentEnabled = true
            };
        }

        public static ReleaseTextRequest CreateReleaseTextRequest(string textId)
        {
            return new ReleaseTextRequest
            {
                Texts = new List<TextDetails>
        {
            new TextDetails
            {
                TextId = textId,
                ObjectNameShort = "METY"
            }
        },
                LocaleCode = "fr-FR",
                Status = "Released",
                TranslatedBy = "simt03",
                UpdatedOn = DateTime.UtcNow
            };
        }

        public static HistoryRequest CreateHistoryRequest(string textId)
        {
            return new HistoryRequest
            {
                TextId = textId,
                SourceLocaleCode = "en-ZZ",
                TargetLocaleCode = "fr-FR",
                ObjectTypeShort = "METY",
                IsParentEnabled = true
            };
        }

        public static List<TranslationUnitRequest> CreateTranslationUnitRequest(string textId, 
                                                                                string source_body_text, 
                                                                                string target_body_text, 
                                                                                string source_abbreviation_text, 
                                                                                string target_abbreviation_text)
        {
            return new List<TranslationUnitRequest>
        {
            CreateRequest(textId, "PRODT-001", source_body_text, target_body_text),
            CreateRequest(textId, "PRODT-002", source_abbreviation_text, target_abbreviation_text),
            CreateRequest(textId, "PRODT-003", string.Empty, string.Empty),
            CreateRequest(textId, "PRODT-004", string.Empty, string.Empty)
        };

        }
        private static TranslationUnitRequest CreateRequest(string text_id,
                                                            string partId, 
                                                            string sourceText, 
                                                            string targetText)
        {
            return new TranslationUnitRequest
            {
                UserID = "SIMT03",
                TextID = text_id,
                TextType_SHORT = "PRODT",
                Part_ID = partId,
                TranslationUnitRequestList = new List<TranslationUnitRequestListItem>
            {
                new TranslationUnitRequestListItem
                {
                    Settings = new TranslationUnitSettings
                    {
                        ExistingTUsUpdateMode = "LeaveUnchanged"
                    },
                    TranslationUnit = new TranslationUnitDetails
                    {
                        Source = new TranslationUnitLanguage
                        {
                            Language = "en-gb",
                            Text = sourceText
                        },
                        Target = new TranslationUnitLanguage
                        {
                            Language = "fr-FR",
                            Text = targetText
                        },
                        TextType = "Product Type",
                        CreatedBy = "MISE",
                        CreationDate = "",
                        UsedBy = "",
                        UseDate = null,
                        ModifiedBy = ""
                    }
                }
            }
            };
        }


    }

}

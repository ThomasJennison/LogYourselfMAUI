using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.ObjectModel;

namespace LogYourself.Services
{
    public class SuggestionService : ISuggestionService
    {
        private static readonly Dictionary<SuggestionTypes, List<string>> _defaults = new Dictionary<SuggestionTypes, List<string>>()
        {
            {SuggestionTypes.Emotions, new List<string>(){"Happiness","Anger","Fear","Sadness" } },
            {SuggestionTypes.Locations,new List<string>(){"Home","Work"} },
            {SuggestionTypes.MealTypes,new List<string>(){"Breakfast","Lunch","Dinner"} },
            {SuggestionTypes.SubstanceNames,new List<string>() {"Coffee","Tobacco","Cannabis","Alcohol"}},
            {SuggestionTypes.SubstanceConsumptionMethods,new List<string>() {"Drank","Smoked","Vaporized"}},
            {SuggestionTypes.Units,new List<string>(){"Cup","g","Cigarette","Drink","Pint"}},
            {SuggestionTypes.MealSizes,new List<string>() {"Small","Modest","Large"}},
            {SuggestionTypes.MealNames,new List<string>(){"Sandwich"} },
            {SuggestionTypes.ActivityNames,new List<string>(){"Played Guitar","Went for a walk"}},
            {SuggestionTypes.SocializationTypes,new List<string>(){"Talked to a friend","Work meeting","Talked to a stranger"}}
        };

        [JsonConverter(typeof(StringEnumConverter))]
        private readonly Dictionary<SuggestionTypes, List<string>> _suggestions;

        public const string SuggestionsFilename = "Suggestions.json";

        public static string FilePath
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, SuggestionsFilename);
            }
        }

        public void Save() => File.WriteAllText(FilePath, JsonConvert.SerializeObject(_suggestions, Formatting.Indented));

        public SuggestionService()
        {
            _suggestions = new Dictionary<SuggestionTypes, List<string>>();

            if (File.Exists(FilePath))
            {
                _suggestions = JsonConvert.DeserializeObject<Dictionary<SuggestionTypes, List<string>>>(File.ReadAllText(FilePath));
            }
            else
            {
                _suggestions = new Dictionary<SuggestionTypes, List<string>>(_defaults);
                Save();
            }

            foreach (object suggestionType in Enum.GetValues(typeof(SuggestionTypes)))
            {
                if (!_suggestions.ContainsKey((SuggestionTypes)suggestionType))
                    _suggestions.Add((SuggestionTypes)suggestionType, new List<string>());
            }
        }

        public ObservableCollection<string> GetSuggestionCollection(SuggestionTypes type)
        {
            return new ObservableCollection<string>(_suggestions[type]);
        }

        public void AddSuggestion(SuggestionTypes type, string suggestion)
        {
            if (!_suggestions[type].Contains(suggestion))
            {
                _suggestions[type].Add(suggestion);
                Save();
            }
        }

        public void RemoveSuggestion(SuggestionTypes types, string suggestion)
        {
            if (_suggestions[types].Contains(suggestion))
            {
                _ = _suggestions[types].Remove(suggestion);
                Save();
            }
        }
    }
}
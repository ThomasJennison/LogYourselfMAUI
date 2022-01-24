using System.Collections.ObjectModel;

namespace LogYourself.Services
{
    public interface ISuggestionService
    {
        ObservableCollection<string> GetSuggestionCollection(SuggestionTypes type);

        void AddSuggestion(SuggestionTypes type, string sugestion);

        void RemoveSuggestion(SuggestionTypes types, string suggestion);
    }
}
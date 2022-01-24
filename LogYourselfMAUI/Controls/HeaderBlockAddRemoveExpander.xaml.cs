using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LogYourself.Services;

namespace LogYourself.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderBlockAddRemoveExpander : Frame
    {
        public HeaderBlockAddRemoveExpander()
        {
            InitializeComponent();
            SuggestionService = DependencyService.Get<ISuggestionService>();
            AddButton.Command = new Command(() => AddItem());
        }

        public ObservableCollection<string> SuggestionItems { get; private set; }
        public ISuggestionService SuggestionService { get; set; }
        public bool InitialSet;

        public string Title
        {
            get { return HeaderLabel.Text; }
            set { HeaderLabel.Text = value; }
        }

        public bool IsEdditingSuggestion
        {
            get { return addNewSwitch.IsToggled; }
            set { addNewSwitch.IsToggled = value; }
        }

        public string SelectedSuggestion
        {
            get { return (string)GetValue(SelectedSuggestionProperty); }
            set { SetValue(SelectedSuggestionProperty, value); }
        }

        public SuggestionTypes BoxType
        {
            get { return (SuggestionTypes)GetValue(BoxTypeProperty); }
            set { SetValue(BoxTypeProperty, value); }
        }

        public string SuggestionPrompt
        {
            get { return suggestionPromptLabel.Text; }
            set { suggestionPromptLabel.Text = value; }
        }


        public static readonly BindableProperty SelectedSuggestionProperty =
            BindableProperty.Create(nameof(SelectedSuggestion), typeof(string), typeof(HeaderBlockAddRemoveExpander),
                default(string), BindingMode.TwoWay, propertyChanged: HandleSuggestionChanged);

        public static readonly BindableProperty BoxTypeProperty =
            BindableProperty.Create(nameof(BoxType), typeof(SuggestionTypes), typeof(HeaderBlockAddRemoveExpander),
                SuggestionTypes.Invalid, BindingMode.TwoWay, propertyChanged: HandleBoxTypeChanged);


        private static void HandleSuggestionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            HeaderBlockAddRemoveExpander block = (HeaderBlockAddRemoveExpander)bindable;

            if (newValue is null)
                return;

            if (!block.InitialSet)
            {
                string type = newValue.ToString();

                if (type == string.Empty)
                    return;

                if (!block.SuggestionItems.Contains(type))
                {
                    block.SuggestionItems.Add(type);
                }

                block.HeaderPicker.SelectedIndex = block.SuggestionItems.IndexOf(type);
                block.InitialSet = true;
            }
        }

        private static void HandleBoxTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            HeaderBlockAddRemoveExpander block = (HeaderBlockAddRemoveExpander)bindable;
            SuggestionTypes type = (SuggestionTypes)newValue;
            block.BoxType = type;

            block.SuggestionItems = block.SuggestionService.GetSuggestionCollection(type);
            block.HeaderPicker.ItemsSource = block.SuggestionItems;
            block.HeaderPicker.SelectedIndex = block.SuggestionItems.IndexOf(block.SelectedSuggestion);

            block.SuggestionPrompt = block.PromptFromSuggestionType();
        }

        public string PromptFromSuggestionType()
        {
            string promptStr = string.Empty;
            switch (BoxType)
            {
                case SuggestionTypes.ActivityNames:
                    promptStr = "Enter a new activity name";
                    break;
                case SuggestionTypes.Emotions:
                    promptStr = "Enter a new emotion";
                    break;
                case SuggestionTypes.Locations:
                    promptStr = "Enter a new location";
                    break;
                case SuggestionTypes.MealNames:
                    promptStr = "Enter a meal name";
                    break;
                case SuggestionTypes.MealSizes:
                    promptStr = "Enter a new meal size";
                    break;
                case SuggestionTypes.MealTypes:
                    promptStr = "Enter a new type of meal";
                    break;
                case SuggestionTypes.SubstanceConsumptionMethods:
                    promptStr = "Enter a new consumption method";
                    break;
                case SuggestionTypes.SubstanceNames:
                    promptStr = "Enter a new substance name";
                    break;
                case SuggestionTypes.Units:
                    promptStr = "Enter a new unit";
                    break;
                case SuggestionTypes.SocializationTypes:
                    promptStr = "How did you socialize?";
                    break;
            }
            return promptStr;
        }

        private void AddItem()
        {
            if (string.IsNullOrEmpty(suggestionEditor.Text))
            {
                return;
            }

            string userInput = suggestionEditor.Text;
            SuggestionItems.Add(userInput);
            HeaderPicker.SelectedIndex = SuggestionItems.IndexOf(userInput);
            SuggestionService.AddSuggestion(BoxType, userInput);
            IsEdditingSuggestion = false;
        }

        private void RemoveButton_Pressed(object sender, EventArgs e)
        {
            if (HeaderPicker.SelectedItem == null)
                return;

            string selectedItem = HeaderPicker.SelectedItem.ToString();

            _ = SuggestionItems.Remove(selectedItem);
        }

        private void HeaderPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HeaderPicker.SelectedIndex == -1)
                return;

            SelectedSuggestion = SuggestionItems[HeaderPicker.SelectedIndex];
        }

        private void AddButton_Pressed(object sender, EventArgs e)
        {

        }
    }
}
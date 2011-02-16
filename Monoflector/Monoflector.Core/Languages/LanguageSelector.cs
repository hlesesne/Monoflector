using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Monoflector.Languages
{
    [Export(typeof(LanguageSelector))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class LanguageSelector : Selector<ILanguageProvider>
    {
        protected override string IdentityFor(ILanguageProvider import)
        {
            return import.Name;
        }

        protected override ILanguageProvider ImportFor(string identity)
        {
            foreach (var item in base.Options)
            {
                if (item.Name == identity)
                    return item;
            }
            return base.Options.First();
        }

    }

    public class MustUseSelectedLanguage : IPartImportsSatisfiedNotification
    {
        [Import(typeof(LanguageSelector))]
        private LanguageSelector _selector;

        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            _selector.SelectionChanged += new EventHandler<SelectionChangedEventArgs<ILanguageProvider>>(_selector_SelectionChanged);
            _theCombo.SelectedItem = _selector.SelectedValue;
        }

        void _selector_SelectionChanged(object sender, SelectionChangedEventArgs<ILanguageProvider> e)
        {
            _theCombo.SelectedItem = _selector.SelectedValue;
            UpdateDissasemblers();
        }
    }
}

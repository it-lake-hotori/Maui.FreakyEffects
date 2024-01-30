using Maui.FreakyEffects.TouchEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maui.FreakyEffects.TouchEffects
{
    public class TouchEffectBehavior : Behavior<View>,ITouchEffectBehavior
    {
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(TouchEffectBehavior), Colors.Transparent);
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TouchEffectBehavior), null);
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TouchEffectBehavior), null);
        public object CommandParameter
        {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty LongTapCommandProperty = BindableProperty.Create(nameof(LongTapCommand), typeof(ICommand), typeof(TouchEffectBehavior), null);
        public ICommand LongTapCommand
        {
            get => (ICommand)GetValue(LongTapCommandProperty);
            set => SetValue(LongTapCommandProperty, value);
        }

        public static readonly BindableProperty LongTapCommandParameterProperty = BindableProperty.Create(nameof(LongTapCommandParameter), typeof(object), typeof(TouchEffectBehavior), null);
        public object LongTapCommandParameter
        {
            get => (object)GetValue(LongTapCommandParameterProperty);
            set => SetValue(LongTapCommandParameterProperty, value);
        }

        //public static readonly BindableProperty ApplyEffectToChildrenProperty = BindableProperty.Create(nameof(ApplyEffectToChildren), typeof(bool), typeof(TouchEffectBehavior), false, BindingMode.Default);
        //public bool ApplyEffectToChildren
        //{
        //    get => (bool)GetValue(ApplyEffectToChildrenProperty);
        //    set => SetValue(ApplyEffectToChildrenProperty, value);
        //}

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            var view = bindable as View;

            TouchEffect.SetColor(view, Color);
            Commands.SetTap(view, Command);
            Commands.SetLongTap(view, LongTapCommand);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
            var view = bindable as View;

            TouchEffect.SetColor(view, Colors.Transparent);
            Commands.SetTap(view, null);
            Commands.SetLongTap(view, null);
        }
    }
}

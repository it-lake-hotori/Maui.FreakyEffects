using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.FreakyEffects.TouchEffects
{
    public interface ITouchEffectBehavior
    {
        object CommandParameter { get; set; }
        object LongTapCommandParameter { get; set; }
    }
}

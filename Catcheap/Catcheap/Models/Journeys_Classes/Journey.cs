/* Unmerged change from project 'Catcheap (net6.0-ios)'
Before:
namespace Catcheap.Models.Journeys
After:
using Catcheap.Models.Journeys;

namespace Catcheap.Models.Journeys.Journeys
*/

/* Unmerged change from project 'Catcheap (net6.0-maccatalyst)'
Before:
namespace Catcheap.Models.Journeys
After:
using Catcheap.Models.Journeys;
using Catcheap.Models.Journeys.Journeys;
using Catcheap.Models.Journeys.Journeys.Journeys;

namespace Catcheap.Models.Journeys.Journeys.Journeys.Journeys
*/

/* Unmerged change from project 'Catcheap (net6.0-windows10.0.19041.0)'
Before:
namespace Catcheap.Models.Journeys
After:
using Catcheap.Models.Journeys;
using Catcheap.Models.Journeys.Journeys;

namespace Catcheap.Models.Journeys.Journeys.Journeys
*/

/* Unmerged change from project 'Catcheap (net6.0-windows10.0.19041.0)'
Before:
using Catcheap.Models.JourneysClasses.Journeys;
After:
using Catcheap;
using Catcheap;
using Catcheap.Models;
using Catcheap.Models.JourneysClasses.Journeys;
*/

namespace Catcheap.Models.Journeys_Classes
{
    public struct Journey : IComparable<Journey>
    {
        public DateTime Date { get; set; }
        public int Dist { get; set; }

        public int CompareTo(Journey other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}

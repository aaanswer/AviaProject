using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Avia
{
    internal class FlightCardCreator
    {
        public FlightCardCreator() { }
        public flightPanel createCard(int flightID, string airline, string origin, string destination, DateTime departureTime, DateTime arrivalTime) 
        {
            flightPanel newFlightPanel = new flightPanel(flightID);

            newFlightPanel.Tag = flightID;
            newFlightPanel.headerLabel.Content = airline + ": " + origin + " - " + destination;
            newFlightPanel.Originlabel.Content = origin;
            newFlightPanel.DestinationLabel.Content = destination;
            newFlightPanel.departureTimeLabel.Content = departureTime.ToString();
            newFlightPanel.arrivalTimeLabel.Content = arrivalTime.ToString();
            newFlightPanel.moreInfoBtn.Tag = newFlightPanel.bookBtn.Tag = newFlightPanel.favoriteBtn.Tag = flightID;

            return newFlightPanel;
        }
    }
}

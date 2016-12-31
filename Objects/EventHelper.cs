using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Expense_Tracker
{
    /// <summary>
    /// Functionality for firing and handling events in C#
    /// </summary>
    public static class EventHelper
    {
        /// <summary>
        /// Fires a generic event.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="handler">The event to fire.</param>
        /// <returns>Returns <c>true</c> if the event is successfully fired otherwise returns <c>false</c>.</returns>
        public static bool FireEvent(object sender, EventHandler handler)
        {
            if (handler == null)
            {
                return false;
            }
            else
            {
                handler(sender, new EventArgs());

                return true;
            }
        }

        /// <summary>
        /// Fires a generic event with arguments.
        /// </summary>
        /// <typeparam name="T">Type of the argument</typeparam>
        /// <param name="sender">The caller.</param>
        /// <param name="handler">The event.</param>
        /// <param name="value">The value of <typeparamref name="T"/> to be sent with the firing of <paramref name="handler"/>.</param>
        /// <returns>Returns <c>true</c> if the event is successfully fired otherwise returns <c>false</c>.</returns>
        public static bool FireEvent<T>(object sender, EventHandler<T> handler, T value)
        {
            if (handler == null)
            {
                return false;
            }
            else
            {
                handler(sender, value);

                return true;
            }
        }

        /// <summary>
        /// Fires a property changed event.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="handler">The event.</param>
        /// <param name="property">The property which is changing.</param>
        /// <returns>Returns <c>true</c> if the event is successfully fired otherwise returns <c>false</c>.</returns>
        public static bool FireEvent(INotifyPropertyChanged sender, PropertyChangedEventHandler handler, [CallerMemberName] string property = null)
        {
            if (handler == null)
            {
                return false;
            }
            else
            {
                handler(sender, new PropertyChangedEventArgs(property));

                return true;
            }
        }
    }
}

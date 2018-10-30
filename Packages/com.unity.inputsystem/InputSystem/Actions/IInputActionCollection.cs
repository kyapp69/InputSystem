using System.Collections.Generic;
using UnityEngine.Experimental.Input.Utilities;

namespace UnityEngine.Experimental.Input
{
    /// <summary>
    /// A collection of <see cref="InputAction">input actions</see>.
    /// </summary>
    public interface IInputActionCollection : IEnumerable<InputAction>
    {
        ////REVIEW: remove `bindingMask` and drive everything through `devices`?
        /// <summary>
        /// Optional mask applied to all bindings in the collection.
        /// </summary>
        /// <remarks>
        /// If this is not null, only bindings that match the mask will be used.
        /// </remarks>
        InputBinding? bindingMask { get; set; }

        ////REVIEW: should this allow restricting to a set of controls instead of confining it to just devices?
        /// <summary>
        /// Devices to use with the actions in this collection.
        /// </summary>
        /// <remarks>
        /// If this is set, actions in the collection will exclusively bind to devices
        /// in the given list. For example, if two gamepads are present in the system yet
        /// only one gamepad is listed here, then a "&lt;Gamepad&gt;/leftStick" binding will
        /// only binding to the gamepad in the list and not to the one that is only available
        /// globally.
        /// </remarks>
        ReadOnlyArray<InputDevice>? devices { get; set; }

        /// <summary>
        /// Check whether the given action is contained in this collection.
        /// </summary>
        /// <param name="action">An arbitrary input action.</param>
        /// <returns>True if the given action is contained in the collection, false if not.</returns>
        /// <remarks>
        /// Calling this method will not allocate GC memory (unlike when iterating generically
        /// over the collection). Also, a collection may have a faster containment check rather than
        /// having to search through all its actions.
        /// </remarks>
        bool Contains(InputAction action);

        /// <summary>
        /// Enable all actions in the collection.
        /// </summary>
        void Enable();

        /// <summary>
        /// Disable all actions in the collection.
        /// </summary>
        void Disable();
    }
}

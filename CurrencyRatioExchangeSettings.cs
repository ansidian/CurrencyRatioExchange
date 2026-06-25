using System;
using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;

namespace CurrencyRatioExchange
{
    public class CurrencyRatioExchangeSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new(true);

        [Menu("Show Calculator", "Display the ratio calculator overlay")]
        public ToggleNode ShowCalculator { get; set; } = new(true);

        [Menu("Click X Offset", "Horizontal offset for input field clicks")]
        public RangeNode<int> ClickXOffset { get; set; } = new(0, -100, 100);

        [Menu("Click Y Offset", "Vertical offset for input field clicks")]
        public RangeNode<int> ClickYOffset { get; set; } = new(0, -100, 100);

        [Menu(
            "Verify Fills",
            "After typing, read the field back from game memory and retry if it doesn't match."
        )]
        public ToggleNode VerifyFills { get; set; } = new(true);

        [Menu("Max Fill Retries", "How many times to re-click and re-type a field that fails verification")]
        public RangeNode<int> MaxFillRetries { get; set; } = new(3, 1, 6);

        [Menu(
            "Abort If Mouse Moves",
            "Cancel the fill immediately if the cursor drifts from where the plugin placed it "
                + "(i.e. you grabbed the mouse), so stray keystrokes never land in the wrong place."
        )]
        public ToggleNode AbortOnMouseMove { get; set; } = new(true);

        [Menu(
            "Park Cursor On Place Order",
            "After a successful fill, move the cursor onto the Place Order button (ready to click) "
                + "instead of returning it to where it started."
        )]
        public ToggleNode MoveCursorToPlaceOrder { get; set; } = new(true);

        [Menu("Show Debug Info", "Display debug information for stock items")]
        public ToggleNode ShowDebugInfo { get; set; } = new(false);
    }
}

# Currency Ratio Exchange Calculator

A Path of Exile 2 plugin for ExileCore2 that provides an in-game calculator overlay for the Currency Exchange window. Calculates perfect whole trades with no partial amounts based on exchange ratios.

## Features

- **Want:Have Ratio Format**: Use in-game ratio format like `1:3` or `2:5`
- **Flexible Input**: Also supports expressions like `1.5`, `3/2`, etc.
- **Maximum Whole Trade Calculation**: Finds the largest possible trade with no leftover currency
- **Exact Buy Amount Calculation**: Enter how much you want to buy and calculate how much you need to offer
- **In-Game Overlay**: Calculator appears next to the Currency Exchange panel when open
- **One-Click Fill**: Button to automatically fill the exchange fields with calculated values
- **Real-Time Calculation**: Updates results as you type
- **Adjustable Click Position**: X/Y offset settings to fine-tune input field targeting

## How It Works

This plugin helps you maximize trades while ensuring no partial currency remains.

### The Algorithm

When you have a certain amount of currency and want to trade at a specific ratio:
1. Enter your currency amount (e.g., 1000)
2. Enter the exchange ratio in Want:Have format (e.g., `1:3` or `2:5`)
3. The plugin finds the maximum amount you can trade that results in whole numbers on both sides

**Example:**
- You have: **1000** Lesser Jeweller's Orbs
- Ratio: **2:3** (Want 2, Have 3)
- Result: **666 : 999** (Trade 999 Lesser for 666 Greater, keep 1)

## Usage

### Opening the Calculator

1. Open the Currency Exchange panel in-game (interact with Faustus)
2. The calculator overlay will automatically appear next to the exchange window

### Using the Calculator

1. **Choose Calculation Mode**:
   - **Max from owned amount**: Type the total amount you have
   - **Buy exact amount**: Type how much you want to buy

2. **Enter Ratio** in Want:Have format:
   - `1:3` = Want 1 for every 3 you have
   - `2:5` = Want 2 for every 5 you have
   - Also supports: `1.5`, `3/2`, etc.

3. **View Result**: The calculator shows `Want : Have` values

4. **Fill Exchange**: Click "Fill Exchange Window" to input the values

### Ratio Format Examples

| Ratio Input | Meaning | Example (1000 currency) |
|-------------|---------|-------------------------|
| `1:3` | 1 wanted per 3 offered | 333 : 999 |
| `2:5` | 2 wanted per 5 offered | 400 : 1000 |
| `1.5` | 1.5 wanted per 1 offered | 1000 : 666 |
| `3/2` | Same as 1.5:1 | 1000 : 666 |

### Exact Buy Amount Example

If you want to buy exactly 100 currency at a `1:3` ratio:
- Mode: **Buy exact amount**
- Amount to Buy: **100**
- Ratio: **1:3**
- Result: **100 : 300**

For decimal market ratios, the offered amount is rounded up to the nearest whole number. For example, buying 10 at `1:4.04` becomes `10 : 41`.

## Settings

| Setting | Description | Default |
|---------|-------------|---------|
| **Enable** | Toggle plugin on/off | True |
| **Show Calculator** | Display calculator overlay | True |
| **Click X Offset** | Horizontal offset for input clicks (-100 to 100) | 0 |
| **Click Y Offset** | Vertical offset for input clicks (-100 to 100) | 0 |

### Adjusting Click Position

If the auto-fill button doesn't click the input fields correctly:
1. Open plugin settings
2. Adjust **Click X Offset** (left/right positioning)
3. Adjust **Click Y Offset** (up/down positioning)
4. Test the fill button and adjust as needed

## UI Layout

```
┌─ Currency Ratio Calculator ────────┐
│ Currency Amount:                   │
│ [Input field]                      │
│                                    │
│ Ratio (Want:Have, e.g., 1:3):     │
│ [Input field]                      │
├────────────────────────────────────┤
│ Result (Want : Have):              │
│        666 : 999                   │
│                                    │
│ [Fill Exchange Window]             │
├────────────────────────────────────┤
│ Enter your currency amount and     │
│ the ratio (Want:Have)...           │
│                                    │
│ Examples:                          │
│ • 1:3 = 1 wanted per 3 offered    │
│ • 2:5 = 2 wanted per 5 offered    │
└────────────────────────────────────┘
```

## Understanding Want:Have Ratios

The ratio format matches what you see in-game:
- **Want**: How much currency you want to receive
- **Have**: How much currency you're offering

**Example: Trading Lesser Jeweller's Orbs for Greater Jeweller's Orbs**

If the exchange rate is 3 Lesser for 1 Greater:
- Ratio: `1:3` (Want 1 Greater : Have 3 Lesser)
- With 1000 Lesser Orbs
- Result: `333 : 999` (Want 333 Greater, Have 999 Lesser)

## Technical Details

### Calculation Algorithm

The plugin uses an iterative algorithm to find the maximum whole trade:
```
For have_amount from total down to 1:
    Calculate: want_amount = have_amount * (want/have ratio)
    If want_amount is a whole number:
        Return (want_amount, have_amount)
```

This ensures:
- ✅ No fractional currency amounts
- ✅ Maximum possible trade size
- ✅ No leftover partial trades

### Ratio Parsing

Supports two input formats:

1. **Want:Have Format** (recommended):
   - `1:3`, `2:5`, `3:7`, etc.
   - Directly matches in-game ratio display

2. **Expression Format** (alternative):
   - Simple decimals: `1.5`, `2.0`
   - Fractions: `3/2` (evaluates to 1.5)
   - Math: `5+1`, `10-2` (using `System.Data.DataTable.Compute()`)

### Click Position

The fill button clicks the center of each input field plus any X/Y offsets you configure. Use the offset settings if the default position doesn't work perfectly for your screen/resolution.

## Installation

1. Place the plugin folder in `ExileCore2/Plugins/Source/CurrencyRatioExchange/`
2. Set the `exilecore2Package` environment variable to your ExileCore2 directory
3. Launch Loader.exe - the plugin will auto-compile
4. Enable in the plugin menu if needed

## Requirements

- .NET 8.0
- ExileCore2
- Path of Exile 2

## Troubleshooting

**Auto-fill not working?**
- Adjust Click X/Y Offset in settings
- Make sure the exchange panel is fully visible
- Try clicking manually first to ensure fields are selectable

**Calculator not appearing?**
- Check that "Show Calculator" is enabled in settings
- Make sure you've opened the Currency Exchange panel (Faustus)

## License

This project is open source and available under the MIT License.

# SauseLabPomProjectStaticDriverTDD

A C# Selenium automation test framework built on the **Page Object Model (POM)** pattern, using **NUnit** as the test runner and targeting the [Sauce Demo](https://www.saucedemo.com) e-commerce application.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# / .NET 8.0 |
| Test Framework | NUnit 3.14.0 |
| Browser Automation | Selenium WebDriver 4.23.0 |
| Reporting | ExtentReports 5.0.5 |
| Logging | log4net 3.0.0 |
| CI/CD | GitHub Actions |

---

## Project Structure

```
SauseLabPomProjectStaticDriverTDD/
├── Credentials/
│   ├── AppConfig.json          # Test user credentials and base URL
│   ├── Log4net.config          # Logging configuration
│   └── CredentialProvider.cs   # Reads credentials from AppConfig.json
├── Drivers/
│   └── WebFactory.cs           # Thread-safe WebDriver factory (Chrome, Edge, Firefox)
├── Pages/
│   ├── BaseClass.cs            # Base class for all page objects
│   ├── LoginPage/
│   │   └── LoginPage.cs
│   ├── ProductPage/
│   │   ├── AddProductToCart.cs
│   │   └── ProductIsAvailable.cs
│   ├── HeaderComponents/
│   │   ├── FilterProducts.cs
│   │   └── LogOutUser.cs
│   └── CheckOutPage/
│       ├── CheckOutProduct.cs
│       ├── CancelOrder.cs
│       └── OrderPlaced.cs
├── Tests/
│   ├── BaseClassTest.cs        # SetUp / TearDown, logging, ExtentReports
│   ├── LoginPageTest/
│   ├── ProductPageTest/
│   ├── HeaderComponentsTest/
│   └── CheckOutPageTest/
├── Util/
│   ├── PageFactory.cs          # Generic page object factory
│   └── Screenshots/
│       └── TakeScreenShot.cs   # Auto-captures screenshots on test failure
├── Logs/                       # Rolling log files (generated at runtime)
├── Error_Screenshots/          # Failure screenshots (generated at runtime)
└── Reports/                    # ExtentReports HTML reports (generated at runtime)
```

---

## Test Coverage

| Test Class | Test Method | Description |
|---|---|---|
| `LoginPageTest` | `LoginPage_Test` | Valid login redirects to product page |
| `LoginPageTest` | `InValidLoginPage` | Locked user stays on login page |
| `AddProductToCartTest` | `AddProductsToCartTest` | Cart count is 2 after adding two products |
| `AddProductToCartTest` | `RemoveFromCartTest` | Cart count resets to empty after removal |
| `ProductIsAvailableTest` | `ShouldShowAvailableProduct` | Product with known ID is visible |
| `ProductIsAvailableTest` | `ProductIsNotAvailableTest` | Product with unknown ID is absent |
| `FilterProductsTest` | `FilterOnProductsTest` | Products reorder correctly after applying a filter |
| `LogOutUserTest` | `UserLogoutTest` | Navigating to checkout after logout shows an error |
| `CheckOutProductTest` | `CheckOutProductsTest` | Checkout page loads after adding products |
| `CancelOrderTest` | `ShouldCancelOrderAndReturnToProductsPage` | Cancelling returns user to Products page |
| `OrderPlacedTest` | `ShouldPlaceOrderSuccessfully` | Order completes with "Thank you for your order!" |

---

## Architecture

### Thread-Safe Driver (`WebFactory.cs`)
`WebFactory` holds a `ThreadLocal<IWebDriver>` so parallel test fixtures each get their own browser instance without sharing state.

### Page Object Model
All UI interactions are encapsulated in page classes that extend `BaseClass`. Tests never call Selenium APIs directly — they call typed page methods that return `Task` or `Task<T>`.

### Async/Await
Every page method and test method is async. Action methods (clicks, key entry) return `Task`; query methods (text, boolean checks) return `Task<T>`. This keeps the framework composable and ready for future async WebDriver integrations.

### Reporting & Logging
- **ExtentReports** generates a timestamped HTML report under `Reports/` after each run.
- **log4net** writes `INFO`/`ERROR` entries to console and a rolling file under `Logs/`.
- On failure, a PNG screenshot is saved to `Error_Screenshots/` with the test name and timestamp.

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Google Chrome (or Edge / Firefox) installed
- ChromeDriver / EdgeDriver / GeckoDriver on your `PATH` (or managed via Selenium Manager)

### Clone and build

```bash
git clone https://github.com/SumantaSwainEpam/SauseLabPomProject.git
cd SauseLabPomProjectStaticDriverTDD
dotnet build
```

### Run all tests

```bash
dotnet test
```

### Run a specific test class

```bash
dotnet test --filter FullyQualifiedName~AddProductToCartTest
```

### Switch browser
Open `Tests/BaseClassTest.cs` and change the browser name in `SetUp`:

```csharp
WebFactory.driver.Value = WebFactory.CreateDriver("edge"); // chrome | edge | firefox
```

---

## Configuration

### `Credentials/AppConfig.json`

```json
{
  "Credentials": {
    "StandardUser":    { "Username": "standard_user",   "Password": "secret_sauce" },
    "LockedOutUser":   { "Username": "locked_out_user", "Password": "secret_sauce" },
    "ProblemUser":     { "Username": "problem_user",    "Password": "secret_sauce" },
    "ErrorUser":       { "Username": "error_user",      "Password": "secret_sauce" },
    "VisualUser":      { "Username": "visual_user",     "Password": "secret_sauce" },
    "AppSettings": {
      "BaseUrl": "https://www.saucedemo.com"
    }
  }
}
```

---

## CI/CD — GitHub Actions

| Workflow | Trigger | Filter |
|---|---|---|
| `AllTestCases.yml` | Push to `master` | All tests |
| `LoginPageTest.yml` | Push to `master` | `LoginPageTest` |
| `AddProductToCartTest.yml` | Push to `master` | `AddProductToCartTest` |
| `ProductIsAvailableTest.yml` | Push to `master` | `ProductIsAvailableTest` |
| `FilterProductsTest.yml` | Push to `master` | `FilterProductsTest` |
| `LogOutUserTest.yml` | Push to `master` | `LogOutUserTest` |
| `CheckOutProductsTest.yml` | Push to `master` | `CheckOutProductsTest` |
| `CancelOrderTest.yml` | Push to `master` | `CancelOrderTest` |
| `OrderPlacedTest.yml` | Push to `master` | `OrderPlacedTest` |

All workflows run on `ubuntu-latest` with .NET 8, headless Chrome.

---

## Outputs (generated at runtime)

| Path | Content |
|---|---|
| `Reports/ExtentReport_<timestamp>.html` | Full HTML test report |
| `Logs/Test_log.log` | Rolling execution log |
| `Error_Screenshots/<TestName>_<timestamp>.Png` | Screenshot on test failure |

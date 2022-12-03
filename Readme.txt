--------------------------------------------------
 1. Models
--------------------------------------------------

--------------------------------------------------
 2. Constants:
--------------------------------------------------
 * Projects:
	1.0. Models
--------------------------------------------------

--------------------------------------------------
 3. Shared:
--------------------------------------------------
 * Projects:
	1.0. Constants
		1.1: Models

 * Packages:
	- <PackageReference Include="suzianna.core" Version="1.1.0" />
--------------------------------------------------

--------------------------------------------------
 4. Technical.Rest:
--------------------------------------------------
 * Projects:
	1.0. Shared
		1.1. Constants
		1.1.1. Models

 * Packages:
	- <PackageReference Include="suzianna.core" Version="1.1.0" />
	- <PackageReference Include="suzianna.rest" Version="1.1.0" />
--------------------------------------------------

--------------------------------------------------
 5. Technical.WebUI:
--------------------------------------------------
* Projects:
	1.0. Shared
		1.1. Constants
		1.1.1. Models

 * Packages:
	- <PackageReference Include="suzianna.core" Version="1.1.0" />
	- <PackageReference Include="selenium.webdriver" Version="4.7.0" />
	- <PackageReference Include="DotNetSeleniumExtras.WaitHelpers" Version="3.11.0" />
	- <PackageReference Include="selenium.webdriver.chromedriver" Version="108.0.5359.7100" />
--------------------------------------------------

--------------------------------------------------
 6. Specs:
--------------------------------------------------
 * Projects:
	1.0. Technical.Rest
	2.0. Technical.WebUI

 * Packages:
	_ <PackageReference Include="xunit" Version="2.4.2" />
	_ <PackageReference Include="coverlet.collector" Version="3.2.0">
	_ <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.4.0" />
	_ <PackageReference Include="xunit.runner.visualstudio" Version="2.4.5">

	- <PackageReference Include="specflow" Version="3.9.74" />
	- <PackageReference Include="restsharp" Version="108.0.3" />
	- <PackageReference Include="suzianna.core" Version="1.1.0" />
	- <PackageReference Include="suzianna.rest" Version="1.1.0" />
	- <PackageReference Include="specflow.xunit" Version="3.9.74" />
	- <PackageReference Include="fluentassertions" Version="6.8.0" />
	- <PackageReference Include="SpecFlow.Tools.MsBuild.Generation" Version="3.9.74" />
	- <PackageReference Include="Microsoft.Extensions.Configuration" Version="7.0.0" />
	- <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="7.0.0" />
	- <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="7.0.0" />
	- <PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="7.0.0" />

 * Web Service(s):
	- Dtat.Wallet
--------------------------------------------------

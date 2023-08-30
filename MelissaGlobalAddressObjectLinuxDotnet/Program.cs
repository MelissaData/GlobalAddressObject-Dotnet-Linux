using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using MelissaData;


namespace MelissaGlobalAddrObjectLinuxDotnet
{
  class Program
  {
    static void Main(string[] args)
    {
      // Variables
      string license = "";
      string testAddrLine1 = "";
      string testAddrLine2 = "";
      string testAddrLine3 = "";
      string testLocality = "";
      string testAdminArea = "";
      string testCountry = "";
      string testPostalCode = "";
      string dataPath = "";

      ParseArguments(ref license, ref testAddrLine1, ref testAddrLine2, ref testAddrLine3, ref testLocality, ref testAdminArea, ref testPostalCode, ref testCountry, ref dataPath, args);

      RunAsConsole(license, testAddrLine1, testAddrLine2, testAddrLine3, testLocality, testAdminArea, testPostalCode, testCountry, dataPath);
    }

    static void ParseArguments(ref string license, ref string testAddrLine1, ref string testAddrLine2, ref string testAddrLine3, ref string testLocality, ref string testAdminArea, ref string testPostalCode, 
      ref string testCountry, ref string dataPath, string[] args)
    {
      for (int i = 0; i < args.Length; i++)
      {
        if (args[i].Equals("--license") || args[i].Equals("-l"))
        {
          if (args[i + 1] != null)
          {
            license = args[i + 1];
          }
        }
        if (args[i].Equals("--addressLine1") || args[i].Equals("-a1"))
        {
          if (args[i + 1] != null)
          {
            testAddrLine1 = args[i + 1];
          }
        }
        if (args[i].Equals("--addressLine2") || args[i].Equals("-a2"))
        {
          if (args[i + 1] != null)
          {
            testAddrLine2 = args[i + 1];
          }
        }
        if (args[i].Equals("--addressLine3") || args[i].Equals("-a3"))
        {
          if (args[i + 1] != null)
          {
            testAddrLine3 = args[i + 1];
          }
        }
        if (args[i].Equals("--locality") || args[i].Equals("-l"))
        {
          if (args[i + 1] != null)
          {
            testLocality = args[i + 1];
          }
        }
        if (args[i].Equals("--administrativeArea") || args[i].Equals("-a"))
        {
          if (args[i + 1] != null)
          {
            testAdminArea = args[i + 1];
          }
        }
        if (args[i].Equals("--postalCode") || args[i].Equals("-p"))
        {
          if (args[i + 1] != null)
          {
            testPostalCode = args[i + 1];
          }
        }
        if (args[i].Equals("--country") || args[i].Equals("-c"))
        {
          if (args[i + 1] != null)
          {
            testCountry = args[i + 1];
          }
        }
        if (args[i].Equals("--dataPath") || args[i].Equals("-d"))
        {
          if (args[i + 1] != null)
          {
            dataPath = args[i + 1];
          }
        }
      }
    }

    static void RunAsConsole(string license, string testAddrLine1, string testAddrLine2, string testAddrLine3, string testLocality, string testAdminArea, string testPostalCode, string testCountry, string dataPath)
    {
      Console.WriteLine("\n\n=========== WELCOME TO MELISSA GLOBAL ADDRESS OBJECT LINUX DOTNET ===========\n");
      
      GlobalAddressObject globalAddrObject = new GlobalAddressObject(license, dataPath);
      
      bool shouldContinueRunning = true;

      if (globalAddrObject.mdGlobalAddrObj.GetOutputParameter("initializeErrorString") != "No error.")
      {
        shouldContinueRunning = false;
      }

      while (shouldContinueRunning)
      {
        DataContainer dataContainer = new DataContainer();

        if (string.IsNullOrEmpty(testAddrLine1) && string.IsNullOrEmpty(testAddrLine2) && string.IsNullOrEmpty(testAddrLine3) && string.IsNullOrEmpty(testLocality) && string.IsNullOrEmpty(testAdminArea) 
          && string.IsNullOrEmpty(testPostalCode) && string.IsNullOrEmpty(testCountry))
        {
          Console.WriteLine("\nFill in each value to see the Address Object results");

          Console.Write("Address Line 1: ");
          dataContainer.AddressLine1 = Console.ReadLine();

          Console.Write("Address Line 2: ");
          dataContainer.AddressLine2 = Console.ReadLine();

          Console.Write("Address Line 3: ");
          dataContainer.AddressLine3 = Console.ReadLine();

          Console.Write("Locality: ");
          dataContainer.Locality = Console.ReadLine();

          Console.Write("Administrative Area: ");
          dataContainer.AdministrativeArea = Console.ReadLine();

          Console.Write("Postal: ");
          dataContainer.PostalCode = Console.ReadLine();

          Console.Write("Country: ");
          dataContainer.Country = Console.ReadLine();
        }
        else
        {
          dataContainer.AddressLine1 = testAddrLine1;
          dataContainer.AddressLine2 = testAddrLine2;
          dataContainer.AddressLine3 = testAddrLine3;
          dataContainer.Locality = testLocality;
          dataContainer.AdministrativeArea = testAdminArea;
          dataContainer.PostalCode = testPostalCode;
          dataContainer.Country = testCountry;
        }

        // Print user input
        Console.WriteLine("\n=================================== INPUTS ==================================\n");
        Console.WriteLine($"\t              Address Line 1: {dataContainer.AddressLine1}");
        Console.WriteLine($"\t              Address Line 2: {dataContainer.AddressLine2}");
        Console.WriteLine($"\t              Address Line 3: {dataContainer.AddressLine3}");
        Console.WriteLine($"\t                    Locality: {dataContainer.Locality}");
        Console.WriteLine($"\t         Administrative Area: {dataContainer.AdministrativeArea}");
        Console.WriteLine($"\t                 Postal Code: {dataContainer.PostalCode}");
        Console.WriteLine($"\t                     Country: {dataContainer.Country}");

        // Execute Global Address Object
        globalAddrObject.ExecuteObjectAndResultCodes(ref dataContainer);

        // Print output
        Console.WriteLine("\n=================================== OUTPUT ==================================\n");
        Console.WriteLine("\n\tGlobal Address Object Information:");

        Console.WriteLine($"\t                MAK: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("MAK")}");
        Console.WriteLine($"\t            Company: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("Organization")}");
        Console.WriteLine($"\t     Address Line 1: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("addressline1")}");
        Console.WriteLine($"\t     Address Line 2: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("addressline2")}");
        Console.WriteLine($"\t     Address Line 3: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("addressline3")}");
        Console.WriteLine($"\t     Address Line 4: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("addressline4")}");
        Console.WriteLine($"\t     Address Line 5: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("addressline5")}");
        Console.WriteLine($"\t           Locality: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("locality")}");
        Console.WriteLine($"\tAdministrative Area: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("administrativeArea")}");
        Console.WriteLine($"\t        Postal Code: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("postalCode")}");
        Console.WriteLine($"\t            Postbox: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("postBox")}");
        Console.WriteLine($"\t            Country: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("countryName")}");
        Console.WriteLine($"\t      Country ISO 2: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("iso2Code")}");
        Console.WriteLine($"\t      Country ISO 3: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("iso3Code")}");
        Console.WriteLine($"\t           Latitude: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("latitude")}");
        Console.WriteLine($"\t          Longitude: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("longitude")}");
        Console.WriteLine($"\t  Formatted Address: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("formattedAddress")}");
        Console.WriteLine($"\t       Result Codes: {globalAddrObject.mdGlobalAddrObj.GetOutputParameter("resultCodes")}");

        /*String[] rs = dataContainer.ResultCodes.Split(',');
        foreach (String r in rs)
          Console.WriteLine($"        {r}: {globalAddrObject.mdGlobalAddrObj.(r, mdGlobalAddr.ResultCdDescOpt.ResultCodeDescriptionLong)}");*/

        bool isValid = false;
        if (!string.IsNullOrEmpty(testAddrLine1 + testAddrLine2 + testAddrLine3 + testLocality + testAdminArea + testPostalCode + testCountry))
        {
          isValid = true;
          shouldContinueRunning = false;
        }
        while (!isValid)
        {
          Console.WriteLine("\nTest another address? (Y/N)");
          string testAnotherResponse = Console.ReadLine();

          if (!string.IsNullOrEmpty(testAnotherResponse))
          {
            testAnotherResponse = testAnotherResponse.ToLower();
            if (testAnotherResponse == "y")
            {
              isValid = true;
            }
            else if (testAnotherResponse == "n")
            {
              isValid = true;
              shouldContinueRunning = false;
            }
            else
            {
              Console.Write("Invalid Response, please respond 'Y' or 'N'");
            }
          }
        }
      }
      Console.WriteLine("\n================== THANK YOU FOR USING MELISSA DOTNET OBJECT ================\n");
    }
  }

  class GlobalAddressObject
  {
    // Path to Global Address Object data files (.dat, etc)
    string dataFilePath;

    // Create instance of Melissa Global Address Object
    public mdGlobalAddr mdGlobalAddrObj = new mdGlobalAddr();

    public GlobalAddressObject(string license, string dataPath)
    {
      // Set license string and set path to data files  (.dat, etc)
      mdGlobalAddrObj.SetLicenseString(license);

      dataFilePath = dataPath;
      mdGlobalAddrObj.SetPathToGlobalAddrFiles(dataFilePath);

      // If you see a different date than expected, check your license string and either download the new data files or use the Melissa Updater program to update your data files.  
      mdGlobalAddr.ProgramStatus pStatus = mdGlobalAddrObj.InitializeDataFiles();

      if (pStatus != mdGlobalAddr.ProgramStatus.ErrorNone)
      {
        Console.WriteLine("Failed to Initialize Object.");
        Console.WriteLine(pStatus);
        return;
      }

      Console.WriteLine($"                       DataBase Date: {mdGlobalAddrObj.GetOutputParameter("databaseDate")}");
      Console.WriteLine($"                     Expiration Date: {mdGlobalAddrObj.GetOutputParameter("databaseExpirationDate")}");

      /**
       * This number should match with the file properties of the Melissa Object binary file.
       * If TEST appears with the build number, there may be a license key issue.
       */
      Console.WriteLine($"                      Object Version: {mdGlobalAddrObj.GetOutputParameter("buildNumber")}\n");
    }

    // This will call the lookup function to process the input address as well as generate the result codes
    public void ExecuteObjectAndResultCodes(ref DataContainer data)
    {
      mdGlobalAddrObj.ClearProperties();

      data.FilterRequest();

      mdGlobalAddrObj.SetInputParameter("inputAddressLine1", data.AddressLine1);
      mdGlobalAddrObj.SetInputParameter("inputAddressLine2", data.AddressLine2);
      mdGlobalAddrObj.SetInputParameter("inputAddressLine3", data.AddressLine3);
      mdGlobalAddrObj.SetInputParameter("inputLocality", data.Locality);
      mdGlobalAddrObj.SetInputParameter("inputAdministrativeArea", data.AdministrativeArea);
      mdGlobalAddrObj.SetInputParameter("inputPostalCode", data.PostalCode);
      mdGlobalAddrObj.SetInputParameter("inputCountry", data.Country);

      mdGlobalAddrObj.VerifyAddress();

      // ResultsCodes explain any issues Global Address Object has with the object.
      // List of result codes for Global Address Object
      // https://wiki.melissadata.com/index.php?title=Result_Code_Details#Global_Address_Object
    }
  }

  public class DataContainer
  {
    public string AddressLine1 { get; set; } = "";
    public string AddressLine2 { get; set; } = "";
    public string AddressLine3 { get; set; } = "";
    public string Locality { get; set; } = "";
    public string AdministrativeArea { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string Country { get; set; } = "";
    public string ResultCodes { get; set; } = "";

    // Filter request method
    public void FilterRequest()
    {
      if (CheckForAreaStack(AddressLine3))
      {
        AddressLine3 = "";
      }
      else if (CheckForAreaStack(AddressLine2))
      {
        AddressLine2 = "";
        AddressLine3 = "";
      }
    }

    // Check for area stack method
    private bool CheckForAreaStack(string addressLine)
    {
      bool localityCheck = false;
      bool adminAreaCheck = false;
      bool postalCheck = false;

      if (!string.IsNullOrEmpty(Locality) && addressLine.Contains(Locality))
      {
        localityCheck = true;
      }
      if (!string.IsNullOrEmpty(AdministrativeArea) && addressLine.Contains(AdministrativeArea))
      {
        adminAreaCheck = true;
      }
      if (!string.IsNullOrEmpty(PostalCode) && addressLine.Contains(PostalCode))
      {
        postalCheck = true;
      }

      if (localityCheck && adminAreaCheck && postalCheck)
      {
        return true;
      }

      return false;
    }
  }
}


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WorkShopNet.App
{

  public class Validator
  {

    static string id_1 = null;
    static string id_2 = "A234";
    static string id_3 = "A123456789012345678901234567890BC";
    static string id_4 = "aBCDEFG12345";

    static void Main(string[] args)
    {
      CallMethod(ValidateStringRegex, "ValidateStringRegex");
      CallMethod(ValidateStringIf, "ValidateStringIf");
      CallMethod(ValidateStringExceptions, "ValidateStringExceptions");
    }



    public static List<string> ValidateStringRegex(string id)
    {
      List<string> listErrors = new List<string>();
      var regexLenghtMin = new Regex(@"^[A-z 0-9]{0,4}$");
      var regexLenghtMax = new Regex(@"^[A-z 0-9]{33,}$");
      if (String.IsNullOrEmpty(id))
      {
        listErrors.Add("the id can't null");
      }
      else
      {
        
        if (regexLenghtMin.IsMatch(id))
        {
          listErrors.Add("Should have minimum 5 characters");
        }
        else if (regexLenghtMax.IsMatch(id))
        {
          listErrors.Add("Should have maximum 32 characters");
        }
        var regex = new Regex(@"^[A-Z].*");
        if (!regex.IsMatch(id))
        {
          listErrors.Add("Should starts with a capital letter");
        }
      }
      return listErrors;
    }
    public static List<string> ValidateStringIf(string id)
    {
      List<string> listErrors = new List<string>();
      if (String.IsNullOrEmpty(id))
      {
        listErrors.Add("the id can't null");
      }
      else
      {
        if (id.Length < 5)
        {
          listErrors.Add("Should have minimum 5 characters");
        }
        else if (id.Length > 32)
        {
          listErrors.Add("Should have maximum 32 characters");
        }
        else if (!id[0].Equals(id[0].ToString().ToUpper()))
        {
          listErrors.Add("Should starts with a capital letter");
        }
      }
      return listErrors;
    }
    public static List<string> ValidateStringExceptions(string id)
    {
      List<string> listErrors = new List<string>();
      try
      {
        if (id.Length < 5)
        {
          throw new Exception("Should have minimum 5 characters");
        }
        else if (id.Length > 32)
        {
          throw new Exception("Should have maximum 32 characters");
        }
      }
      catch (Exception e)
      {
        listErrors.Add(e.Message);
      }
      try
      {
        if (id[0].Equals(id[0].ToString().ToUpper()))
        {
          throw new Exception("Should starts with a capital letter");
        }
      }
      catch (Exception e)
      {
        listErrors.Add(e.Message);
      }

      return listErrors;
    }


    delegate List<string> ValidateMethod(string id);

    static void CallMethod(ValidateMethod method, string nameMethod)
    {
      int cycles_max = 1_000_000;
      long before, after;
      int count;
      Stopwatch timeMeasure;
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      before = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
      count = 0;
      timeMeasure = new Stopwatch();
      timeMeasure.Start();
      while (count < cycles_max)
      {
        method(id_1);
        method(id_2);
        method(id_3);
        method(id_4);
        count++;
      }
      timeMeasure.Stop();
      after = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
      Console.WriteLine($"Time {nameMethod}: {timeMeasure.Elapsed.TotalMilliseconds} ms and virtualMemory: {GetMemoryUsage(before, after)} KB");
    }


    // ***************************************************

    static long GetMemoryUsage(long before, long after)
    {
      return (after - before) / 1024;
    }

  }
}
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace MelissaData {
	public class mdGlobalAddr : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			ErrorNone = 0,
			ErrorOther = 1,
			ErrorOutOfMemory = 2,
			ErrorRequiredFileNotFound = 3,
			ErrorFoundOldFile = 4,
			ErrorDatabaseExpired = 5,
			ErrorLicenseExpired = 6
		}
		public enum AccessType {
			Local = 0,
			Remote = 1
		}
		public enum DiacriticsMode {
			Auto = 0,
			On = 1,
			Off = 2
		}
		public enum StandardizeMode {
			ShortFormat = 0,
			LongFormat = 1,
			AutoFormat = 2
		}
		public enum SuiteParseMode {
			ParseSuite = 0,
			CombineSuite = 1
		}
		public enum AliasPreserveMode {
			ConvertAlias = 0,
			PreserveAlias = 1
		}
		public enum AutoCompletionMode {
			AutoCompleteSingleSuite = 0,
			AutoCompleteRangedSuite = 1,
			AutoCompletePlaceHolderSuite = 2,
			AutoCompleteNoSuite = 3
		}
		public enum ResultCdDescOpt {
			ResultCodeDescriptionLong = 0,
			ResultCodeDescriptionShort = 1
		}
		public enum MailboxLookupMode {
			MailboxNone = 0,
			MailboxExpress = 1,
			MailboxPremium = 2
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdGlobalAddrUnmanaged {
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrCreate();
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGlobalAddrDestroy(IntPtr i);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGlobalAddrSetLicenseString(IntPtr i, IntPtr p1);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrSetPathToGlobalAddrFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGlobalAddrSetPathToGlobalAddrFiles(IntPtr i, IntPtr p1);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGlobalAddrInitializeDataFiles(IntPtr i);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrClearProperties", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGlobalAddrClearProperties(IntPtr i);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrSetInputParameter", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGlobalAddrSetInputParameter(IntPtr i, IntPtr pszParamName, IntPtr pszParamValue);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrVerifyAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdGlobalAddrVerifyAddress(IntPtr i);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrGetOutputParameter", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrGetOutputParameter(IntPtr i, IntPtr pszParamName);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrTransliterateText", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrTransliterateText(IntPtr i, IntPtr pszInput, IntPtr pszInputScript, IntPtr pszOutputScript);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrGetCurrentAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrGetCurrentAtomSet(IntPtr i);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrInputsAsAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrInputsAsAtomSet(IntPtr i);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrRightFieldResultsAsAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrRightFieldResultsAsAtomSet(IntPtr i, IntPtr pszAtomSet);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrTokenizerResultsAsAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrTokenizerResultsAsAtomSet(IntPtr i, IntPtr pszAtomSet);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrInputMapperResultsAsAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrInputMapperResultsAsAtomSet(IntPtr i, IntPtr pszAtomSetArray);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrMatchEngineResultsAsAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrMatchEngineResultsAsAtomSet(IntPtr i, IntPtr pszAtomSetArray);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrOutputMappingResultsAsAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdGlobalAddrOutputMappingResultsAsAtomSet(IntPtr i, IntPtr pszAtomSet);
			[DllImport("mdGlobalAddr", EntryPoint = "mdGlobalAddrSetOutputsFromAtomSet", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdGlobalAddrSetOutputsFromAtomSet(IntPtr i, IntPtr pszAtomSet);
		}

		public mdGlobalAddr() {
			i = mdGlobalAddrUnmanaged.mdGlobalAddrCreate();
		}

		~mdGlobalAddr() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdGlobalAddrUnmanaged.mdGlobalAddrDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public bool SetLicenseString(string p1) {
			Utf8String u_p1 = new Utf8String(p1);
			return (mdGlobalAddrUnmanaged.mdGlobalAddrSetLicenseString(i, u_p1.GetUtf8Ptr()) != 0);
		}

		public void SetPathToGlobalAddrFiles(string p1) {
			Utf8String u_p1 = new Utf8String(p1);
			mdGlobalAddrUnmanaged.mdGlobalAddrSetPathToGlobalAddrFiles(i, u_p1.GetUtf8Ptr());
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)mdGlobalAddrUnmanaged.mdGlobalAddrInitializeDataFiles(i);
		}

		public void ClearProperties() {
			mdGlobalAddrUnmanaged.mdGlobalAddrClearProperties(i);
		}

		public bool SetInputParameter(string pszParamName, string pszParamValue) {
			Utf8String u_pszParamName = new Utf8String(pszParamName);
			Utf8String u_pszParamValue = new Utf8String(pszParamValue);
			return (mdGlobalAddrUnmanaged.mdGlobalAddrSetInputParameter(i, u_pszParamName.GetUtf8Ptr(), u_pszParamValue.GetUtf8Ptr()) != 0);
		}

		public int VerifyAddress() {
			return mdGlobalAddrUnmanaged.mdGlobalAddrVerifyAddress(i);
		}

		public string GetOutputParameter(string pszParamName) {
			Utf8String u_pszParamName = new Utf8String(pszParamName);
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrGetOutputParameter(i, u_pszParamName.GetUtf8Ptr()));
		}

		public string TransliterateText(string pszInput, string pszInputScript, string pszOutputScript) {
			Utf8String u_pszInput = new Utf8String(pszInput);
			Utf8String u_pszInputScript = new Utf8String(pszInputScript);
			Utf8String u_pszOutputScript = new Utf8String(pszOutputScript);
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrTransliterateText(i, u_pszInput.GetUtf8Ptr(), u_pszInputScript.GetUtf8Ptr(), u_pszOutputScript.GetUtf8Ptr()));
		}

		public string GetCurrentAtomSet() {
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrGetCurrentAtomSet(i));
		}

		public string InputsAsAtomSet() {
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrInputsAsAtomSet(i));
		}

		public string RightFieldResultsAsAtomSet(string pszAtomSet) {
			Utf8String u_pszAtomSet = new Utf8String(pszAtomSet);
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrRightFieldResultsAsAtomSet(i, u_pszAtomSet.GetUtf8Ptr()));
		}

		public string TokenizerResultsAsAtomSet(string pszAtomSet) {
			Utf8String u_pszAtomSet = new Utf8String(pszAtomSet);
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrTokenizerResultsAsAtomSet(i, u_pszAtomSet.GetUtf8Ptr()));
		}

		public string InputMapperResultsAsAtomSet(string pszAtomSetArray) {
			Utf8String u_pszAtomSetArray = new Utf8String(pszAtomSetArray);
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrInputMapperResultsAsAtomSet(i, u_pszAtomSetArray.GetUtf8Ptr()));
		}

		public string MatchEngineResultsAsAtomSet(string pszAtomSetArray) {
			Utf8String u_pszAtomSetArray = new Utf8String(pszAtomSetArray);
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrMatchEngineResultsAsAtomSet(i, u_pszAtomSetArray.GetUtf8Ptr()));
		}

		public string OutputMappingResultsAsAtomSet(string pszAtomSet) {
			Utf8String u_pszAtomSet = new Utf8String(pszAtomSet);
			return Utf8String.GetUnicodeString(mdGlobalAddrUnmanaged.mdGlobalAddrOutputMappingResultsAsAtomSet(i, u_pszAtomSet.GetUtf8Ptr()));
		}

		public void SetOutputsFromAtomSet(string pszAtomSet) {
			Utf8String u_pszAtomSet = new Utf8String(pszAtomSet);
			mdGlobalAddrUnmanaged.mdGlobalAddrSetOutputsFromAtomSet(i, u_pszAtomSet.GetUtf8Ptr());
		}

		private class Utf8String : IDisposable {
			private IntPtr utf8String = IntPtr.Zero;

			public Utf8String(string str) {
				if (str == null)
					str = "";
				byte[] buffer = Encoding.UTF8.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				utf8String = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, utf8String, buffer.Length);
			}

			~Utf8String() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(utf8String);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetUtf8Ptr() {
				return utf8String;
			}

			public static string GetUnicodeString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return Encoding.UTF8.GetString(buffer);
			}
		}
	}
}

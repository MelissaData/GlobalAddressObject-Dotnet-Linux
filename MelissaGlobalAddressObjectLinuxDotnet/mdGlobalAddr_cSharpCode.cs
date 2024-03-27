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
			EncodedString u_p1 = new EncodedString(p1);
			return (mdGlobalAddrUnmanaged.mdGlobalAddrSetLicenseString(i, u_p1.GetPtr()) != 0);
		}

		public void SetPathToGlobalAddrFiles(string p1) {
			EncodedString u_p1 = new EncodedString(p1);
			mdGlobalAddrUnmanaged.mdGlobalAddrSetPathToGlobalAddrFiles(i, u_p1.GetPtr());
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)mdGlobalAddrUnmanaged.mdGlobalAddrInitializeDataFiles(i);
		}

		public void ClearProperties() {
			mdGlobalAddrUnmanaged.mdGlobalAddrClearProperties(i);
		}

		public bool SetInputParameter(string pszParamName, string pszParamValue) {
			EncodedString u_pszParamName = new EncodedString(pszParamName);
			EncodedString u_pszParamValue = new EncodedString(pszParamValue);
			return (mdGlobalAddrUnmanaged.mdGlobalAddrSetInputParameter(i, u_pszParamName.GetPtr(), u_pszParamValue.GetPtr()) != 0);
		}

		public int VerifyAddress() {
			return mdGlobalAddrUnmanaged.mdGlobalAddrVerifyAddress(i);
		}

		public string GetOutputParameter(string pszParamName) {
			EncodedString u_pszParamName = new EncodedString(pszParamName);
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrGetOutputParameter(i, u_pszParamName.GetPtr()));
		}

		public string TransliterateText(string pszInput, string pszInputScript, string pszOutputScript) {
			EncodedString u_pszInput = new EncodedString(pszInput);
			EncodedString u_pszInputScript = new EncodedString(pszInputScript);
			EncodedString u_pszOutputScript = new EncodedString(pszOutputScript);
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrTransliterateText(i, u_pszInput.GetPtr(), u_pszInputScript.GetPtr(), u_pszOutputScript.GetPtr()));
		}

		public string GetCurrentAtomSet() {
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrGetCurrentAtomSet(i));
		}

		public string InputsAsAtomSet() {
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrInputsAsAtomSet(i));
		}

		public string RightFieldResultsAsAtomSet(string pszAtomSet) {
			EncodedString u_pszAtomSet = new EncodedString(pszAtomSet);
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrRightFieldResultsAsAtomSet(i, u_pszAtomSet.GetPtr()));
		}

		public string TokenizerResultsAsAtomSet(string pszAtomSet) {
			EncodedString u_pszAtomSet = new EncodedString(pszAtomSet);
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrTokenizerResultsAsAtomSet(i, u_pszAtomSet.GetPtr()));
		}

		public string InputMapperResultsAsAtomSet(string pszAtomSetArray) {
			EncodedString u_pszAtomSetArray = new EncodedString(pszAtomSetArray);
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrInputMapperResultsAsAtomSet(i, u_pszAtomSetArray.GetPtr()));
		}

		public string MatchEngineResultsAsAtomSet(string pszAtomSetArray) {
			EncodedString u_pszAtomSetArray = new EncodedString(pszAtomSetArray);
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrMatchEngineResultsAsAtomSet(i, u_pszAtomSetArray.GetPtr()));
		}

		public string OutputMappingResultsAsAtomSet(string pszAtomSet) {
			EncodedString u_pszAtomSet = new EncodedString(pszAtomSet);
			return EncodedString.GetEncodedString(mdGlobalAddrUnmanaged.mdGlobalAddrOutputMappingResultsAsAtomSet(i, u_pszAtomSet.GetPtr()));
		}

		public void SetOutputsFromAtomSet(string pszAtomSet) {
			EncodedString u_pszAtomSet = new EncodedString(pszAtomSet);
			mdGlobalAddrUnmanaged.mdGlobalAddrSetOutputsFromAtomSet(i, u_pszAtomSet.GetPtr());
		}

		private class EncodedString : IDisposable {
			private IntPtr encodedString = IntPtr.Zero;
			private static Encoding encoding = Encoding.UTF8;

			public EncodedString(string str) {
				if (str == null)
					str = "";
				byte[] buffer = encoding.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				encodedString = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, encodedString, buffer.Length);
			}

			~EncodedString() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(encodedString);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetPtr() {
				return encodedString;
			}

			public static string GetEncodedString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return encoding.GetString(buffer);
			}
		}
	}
}

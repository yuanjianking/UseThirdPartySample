#define EXPORTS
#ifdef EXPORTS
#define DLL_API 
#else
#define DLL_API __declspec(dllimport)
#endif


#ifdef __cplusplus
extern "C" {
#endif

	DLL_API int sub(int x, int y);

#ifdef __cplusplus
}
#endif


#pragma once

#ifdef MATRIX_MULTIPLICATION_LIBRARY_EXPORTS
#define MATRIX_MULTIPLICATION_LIBRARY_API __declspec(dllexport)
#else
#define MATRIX_MULTIPLICATION_LIBRARY_API __declspec(dllimport)
#endif

extern "C" MATRIX_MULTIPLICATION_LIBRARY_API int exemplary_procedure();
#pragma once

#ifdef MYJSONPARSER_EXPORTS
#define JSON_API __declspec(dllexport)
#else
#define JSON_API __declspec(dllimport)
#endif

extern "C" {
    
    JSON_API bool ParseJson(const char* jsonString);
}
#include "pch.h" 
#include "HidecosJsonParser.h"
#include <iostream>

bool ParseJson(const char* jsonString) {
    if (jsonString == nullptr) return false;

    // Burada JSON okuma mantığın yer alacak (Tokenize, Parse vb.)
    // Şimdilik sadece gelen string'i ekrana yazdıralım:
    std::cout << "C++ tarafina ulasan veri: " << jsonString << std::endl;

    return true;
}
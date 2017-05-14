namespace AlgorithmFS

open System;

module StringUtils = 
    let IsPalindrome (word:string) = 
        let rev (word:string) = 
            String(Array.rev(word.ToCharArray()))
        word = rev word

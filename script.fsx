open System
#load "Lib.fs"


open ChynoSurf

    let data =
        "73167176531330624919225119674426574742355349194934" +
        "96983520312774506326239578318016984801869478851843" +
        "85861560789112949495459501737958331952853208805511" +
        "12540698747158523863050715693290963295227443043557" +
        "66896648950445244523161731856403098711121722383113" +
        "62229893423380308135336276614282806444486645238749" +
        "30358907296290491560440772390713810515859307960866" +
        "70172427121883998797908792274921901699720888093776" +
        "65727333001053367881220235421809751254540594752243" +
        "52584907711670556013604839586446706324415722155397" +
        "53697817977846174064955149290862569321978468622482" +
        "83972241375657056057490261407972968652414535100474" +
        "82166370484403199890008895243450658541227588666881" +
        "16427171479924442928230863465674813919123162824586" +
        "17866458359124566529476545682848912883142607690042" +
        "24219022671055626321111109370544217506941658960408" +
        "07198403850962455444362981230987879927244284909188" +
        "84580156166097919133875499200524063689912560717606" +
        "05886116467109405077541002256983155200055935729725" +
        "71636269561882670428252483600823257530420752963450"

     //let prnt (d : string) =  printfn  "Data : %c"  d[0]

     let explode (x : string ) = 
         [|for c in x ->  System.Char.GetNumericValue(c)|]

    let dt = explode data

//The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
//Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
      let tst = 7 * 3 * 1 * 6

      type Calc = { Highest : int ; CurrentIndex: int; CurrentValue: int}
      let rec f  (x  : Calc) = 
           if x.CurrentIndex >= 996 then
               x
            else
               let oldValuesToUse = x.CurrentValue / (int)dt.[x.CurrentIndex - 3]
               let newValue = oldValuesToUse * (int)dt.[x.CurrentIndex + 3]
              // let mutable hst = x.Highest
               let hst = if newValue > x.Highest then  newValue else x.Highest
               f {Highest = hst ; CurrentIndex = (int)(x.CurrentIndex + 1); CurrentValue = newValue}

    
    let NewValue (x : Calc) = (int)dt.[x.CurrentIndex ]  * (int)dt.[x.CurrentIndex + 1] * (int)dt.[x.CurrentIndex + 2] * (int)dt.[x.CurrentIndex + 3]


    let rec f2 (x:Calc) =
        match x with
        | x when x.CurrentIndex >= 996  -> x
        | x when (int)dt.[x.CurrentIndex] = 0 -> f2 {Highest = x.Highest ; CurrentIndex = x.CurrentIndex + 1; CurrentValue = x.CurrentValue} 
        | x when  NewValue(x) > x.Highest -> f2 {Highest = NewValue(x); CurrentIndex = x.CurrentIndex + 1; CurrentValue = NewValue(x)}
        | x when  NewValue(x) <= x.Highest -> f2 {Highest = x.Highest; CurrentIndex = x.CurrentIndex + 1; CurrentValue = NewValue(x)}
        | x -> x  
    
        

     //   | Color.Green -> printfn "Green"
      //  | Color.Blue -> printfn "Blue"
     //   | _ -> ()
     
 let fcalc = f2 { Highest = 126 ; CurrentIndex = 3; CurrentValue = 126}


open System.Runtime.InteropServices

[<DllImport("libmath.so", EntryPoint="double_it")>]
extern int doubleIt(int x)

[<EntryPoint>]
let main argv =
  let x = 2

  printfn $"x = %i{x}"
  printfn $"doubleIt x = %i{doubleIt x}"

  0

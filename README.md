# bazel-fsharp-native

The goal is to build an F# executable that depends on a C library.

Without Bazel...

```bash
dotnet tool restore
dotnet paket restore

cc -fpic -shared -o libmath.so ./math.c

LD_LIBRARY_PATH=. dotnet run
```

With Bazel...

```bash
bazel run //:app
```

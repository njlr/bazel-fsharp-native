# bazel-fsharp-native

The goal is to build an F# executable that depends on a C library.

Without Bazel...

```bash
dotnet tool restore
dotnet paket restore

cc -fpic -shared -o libmath.so ./math.c     # Linux
cc -fpic -shared -o libmath.dylib ./math.c  # macOS

dotnet run
```

`app.fsproj` copies the shared library next to `app.dll`, where `[<DllImport("math")>]` finds it,
so no `LD_LIBRARY_PATH` is needed (macOS ignores it anyway).

With Bazel...

```bash
bazel run //:app
```

The C library is built as a shared library (`//:math_shared`) and wrapped in an `import_library`
with `native = [...]` (see [rules_dotnet#535](https://github.com/bazel-contrib/rules_dotnet/pull/535)).
rules_dotnet then lists it in the generated `.deps.json`, so `[<DllImport("math")>]` resolves it
without any custom loading code.

To update NuGet dependencies, edit `paket.dependencies` and run `./sync-paket.sh`.

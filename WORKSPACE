load("@bazel_tools//tools/build_defs/repo:git.bzl", "git_repository")
load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")

http_archive(
  name = "rules_dotnet",
  sha256 = "2650540b29ef1b31b665305bb13497d25d5f565bde459b3e614474177783c7e0",
  strip_prefix = "rules_dotnet-0.8.9",
  url = "https://github.com/bazelbuild/rules_dotnet/releases/download/v0.8.9/rules_dotnet-v0.8.9.tar.gz",
)

load(
  "@rules_dotnet//dotnet:repositories.bzl",
  "dotnet_register_toolchains",
  "rules_dotnet_dependencies",
)

rules_dotnet_dependencies()

dotnet_register_toolchains("dotnet", "6.0.406")

load("@rules_dotnet//dotnet:rules_dotnet_nuget_packages.bzl", "rules_dotnet_nuget_packages")

rules_dotnet_nuget_packages()

load("@rules_dotnet//dotnet:paket2bazel_dependencies.bzl", "paket2bazel_dependencies")

paket2bazel_dependencies()

load("//deps:paket.bzl", "paket")

paket()

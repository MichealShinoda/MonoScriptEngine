#include <iostream>
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>

MonoDomain* domain;
MonoAssembly* assembly;
#define format(fmt,...) printf(fmt "\n",__VA_ARGS__);

int main(int argc, char* argv[])
{
	format("Running Mono...");
	mono_set_dirs("monolib", "monolib/etc");
	domain = mono_jit_init_version("myapp", "v4.0.30319");
	assembly = mono_domain_assembly_open(domain, "MonoCompiler.exe");
	if (!assembly) return -1;
	mono_jit_exec(domain, assembly, argc, argv);
	getchar();
	return 1;
}
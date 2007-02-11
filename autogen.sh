chmod +x ./tools/Prebuild/prebuild
aclocal -I .
automake -a
autoconf
./configure $*

bitwizard
=========

Unaligned bit access and bitwise read/write streams for C#

This is a project to bring a bunch of little snippets together and under test.

Todo
----
* BitReader
  * Add read-ahead cache and make forwards-only (so can be used with regular streams)
  * Add signed, varying length int readers
  * Change intel/network order methods to a flag in the class
  * Read utf-8 character (including multi-byte)
* BitWriter
  * Write it!


# FileSplit
Split and combine files with CLI tool.

# Usage:



To split a file you can put 1 or 2 arguments:

- Just name of file you want to split (defaults to splitting into 8MB files).
```
FileSplit "my_file.txt"
```

- Name of file AND number of bytes you wish to split it into
```
FileSplit "my_file.txt" 10000
```

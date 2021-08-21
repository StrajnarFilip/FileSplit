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

To combine a file you can just put -c or --combine option, which will search for first (hopefully only) .json file
```
FileSplit -c
```
```
FileSplit --combine
```
You can also specify the json file in some other directory explicitly. Note that the file parts still have to be in the same directory as the .json!
```
FileSplit -c "subdirectory/HEXHASH.json"
```

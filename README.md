# Console Commands Shortcut
Windows Application (C# based) to allow the user to set an aliases for windows and unix termials easily

## Screenshot:
![Console Commands Shortcut interface](https://github.com/ibraheem-ghazi/console-commands-shortcut/blob/master/screenshot.png?raw=true)

## Notes:
- The generated scripts are in format `.bat` and `.sh` so it's compatible with most of the terminal that can be used in windows environment
- In case the saved command not working this usually means the application fails to add the path where it load scripts to PATH env variable, so you need to add it manually
	- the path is: `C:\ProgramData\ConsoleCommandsShortcut\Commands`

# About `{p}`
the signature `{p}` indicate that any command parameter will be added at this place.
for example:
```
name: test
command: call {p} something
```
if called `test app app2` it will be converted to `call app app2 something`
if called `test` it will ber converted to `call something`

# New Features!
currently, I'm not intending to add any new features, but if you would like to share enhancements you made, don't hesitate to open a pull request.


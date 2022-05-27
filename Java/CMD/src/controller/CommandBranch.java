package controller;
import view.*;
import java.util.Scanner;
public class CommandBranch {
	Information information;
	CommandResult commandResult;
	public CommandBranch(){
		information=new Information();
		commandResult=new CommandResult();
	}
	public void excuteCMD() {
		boolean isExited=false;
		information.showOSInformation(getOSversion());
		while(!isExited) {
			information.showCurrentDirectory(getCurrentDirectory());
			isExited=detectCommand();
		}
	}
	private String getOSversion() {
		String version=System.getProperty("os.version");
		return version;
	}
	private String getCurrentDirectory() {
		String currentDirectory="현재위치";
		return currentDirectory;
	}
	private boolean detectCommand() {
		Scanner userInput=new Scanner(System.in);
		String firstKeyWord=userInput.next();
		switch(firstKeyWord.toLowerCase()) {
			case "cd":
				
				break;
			case "dir":
				
				break;
			case "cls":
				commandResult.clearConsole();
				break;
			case "help":
				commandResult.showAllCommand();
				break;
			case "copy":
				
				break;
			case "move":
				
				break;
			case "exit":
				return true;
			default:
				information.informNoneCommand(firstKeyWord);
		}
		return false;
	}
}

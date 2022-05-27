package controller;
import view.*;
import model.*;
import controller.commands.*;
import java.util.Scanner;
public class CommandBranch {
	Information information;
	CommandResult commandResult;
	DirectoryData directoryData;
	CD commandCD;
	CLS commandCLS;
	COPY commandCOPY;
	DIR commandDIR;
	HELP commandHELP;
	MOVE commandMOVE;
	public CommandBranch(){
		information=new Information();
		commandResult=new CommandResult();
		directoryData=new DirectoryData();
		commandCD= new CD();
		commandCLS=new CLS();
		commandCOPY=new COPY();
		commandDIR=new DIR();
		commandHELP=new HELP(commandResult);
		commandMOVE=new MOVE();
	}
	public void excuteCMD() {
		boolean isExited=false;
		information.showOSInformation(getOSversion());
		directoryData.setDirectory(System.getProperty("user.home"));
		while(!isExited) {
			information.showCurrentDirectory(directoryData.getDirectory());
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
		if(userInput.hasNextLine())
			System.out.println("있음");
		//String command=userInput.nextLine()
		/*;
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
				//commandHELP.detectLine(userInput.next());
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
		*/
		return false;
	}
	//private String detectHelp() {
		
	//}
}

package controller;
import view.*;
import utility.*;
import model.*;
import controller.commands.*;
import java.util.Scanner;
public class CommandBranch {
	Information information;
	CommandResult commandResult;
	DirectoryData directoryData;
	CD commandCD;
	//CLS commandCLS;
	COPY commandCOPY;
	DIR commandDIR;
	//HELP commandHELP;
	MOVE commandMOVE;
	public CommandBranch(){
		information=new Information();
		commandResult=new CommandResult();
		directoryData=new DirectoryData();
		commandCD= new CD(commandResult,directoryData);
		//commandCLS=new CLS();
		commandCOPY=new COPY();
		commandDIR=new DIR();
		//commandHELP=new HELP(commandResult);
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
		String command=userInput.nextLine();
		String firstKeyWord=UserInputProcessing.getInstance().splitCommand(command);
		String extraCommand;
		switch(UserInputProcessing.getInstance().extractCommand(firstKeyWord)) {
			case 1:
				System.out.println("cd");
				break;
			default:
				information.informNoneCommand(firstKeyWord);
		}
		/*
		switch(firstKeyWord.toLowerCase()) {
			case "cd":case "cd..":case "cd\\":case "cd..\\..":
				extraCommand=command.trim().toLowerCase().replace("cd", "").trim();
				commandCD.excuteCommand(extraCommand);
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
}

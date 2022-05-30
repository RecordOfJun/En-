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
	UserInputProcessing userInputProcessing;
	public CommandBranch(){
		information=new Information();
		commandResult=new CommandResult();
		directoryData=new DirectoryData();
		commandCD= new CD(commandResult,directoryData);
		//commandCLS=new CLS();
		commandCOPY=new COPY(commandResult,directoryData);
		commandDIR=new DIR(commandResult,directoryData);
		//commandHELP=new HELP(commandResult);
		commandMOVE=new MOVE();
		userInputProcessing=new UserInputProcessing();
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
	private boolean detectCommand() {
		Scanner userInput=new Scanner(System.in);
		String command=userInput.nextLine();
		String firstKeyWord=userInputProcessing.splitCommand(command);
		String extraCommand;
		switch(userInputProcessing.extractCommand(firstKeyWord)) {
		case 1:
			extraCommand=command.trim().toLowerCase().substring(2);
			commandCD.excuteCommand(extraCommand);
			break;
		case 2:
			extraCommand=command.trim().toLowerCase().substring(3);
			commandDIR.excuteCommand(extraCommand);
			break;
		case 5:
			commandResult.clearConsole();
			break;
		case 4:
			commandResult.showAllCommand();
			//commandHELP.detectLine(userInput.next());
			break;
		case 3:
			extraCommand=command.trim().toLowerCase().substring(4);
			commandCOPY.excuteCommand(extraCommand);
			break;
		case 6:
			extraCommand=command.trim().toLowerCase().substring(4);
			commandCOPY.excuteCommand(extraCommand);
			break;
		case 7:
			return true;
		default:
			information.informNoneCommand(firstKeyWord);
	}
		return false;
	}
}

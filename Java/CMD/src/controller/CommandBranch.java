package controller;
import view.*;
import utility.*;
import model.*;
import controller.commands.*;
import controller.commands.tranformation.COPY;
import controller.commands.tranformation.MOVE;

import java.util.Scanner;
public class CommandBranch {
	Information information;
	CommandResult commandResult;
	DirectoryData directoryData;
	CD commandCD;
	COPY commandCOPY;
	DIR commandDIR;
	MOVE commandMOVE;
	UserInputProcessing userInputProcessing;
	public CommandBranch(){
		information=new Information();
		commandResult=new CommandResult();
		directoryData=new DirectoryData();
		commandCD= new CD(commandResult,directoryData);
		commandCOPY=new COPY(commandResult,directoryData);
		commandDIR=new DIR(commandResult,directoryData);
		commandMOVE=new MOVE(commandResult,directoryData);
		userInputProcessing=new UserInputProcessing();
	}
	public void excuteCMD() {
		boolean isExited=false;
		information.showOSInformation();
		directoryData.setDirectory(System.getProperty("user.home"));
		while(!isExited) {
			information.showCurrentDirectory(directoryData.getDirectory());
			isExited=detectCommand();
		}
	}
	private boolean detectCommand() {
		Scanner userInput=new Scanner(System.in);
		String command=userInput.nextLine();
		String firstKeyWord=userInputProcessing.splitCommand(command);
		String extraCommand;
		switch(userInputProcessing.extractCommand(firstKeyWord)) {
		case Constant.CD:
			extraCommand=command.trim().toLowerCase().substring(Constant.CDLENGTH);
			commandCD.excuteCommand(extraCommand);
			break;
		case Constant.DIR:
			extraCommand=command.trim().toLowerCase().substring(Constant.DIRLENGTH);
			information.showDirveInformation();
			commandDIR.excuteCommand(extraCommand);
			break;
		case Constant.CLS:
			commandResult.clearConsole();
			break;
		case Constant.HELP:
			commandResult.showAllCommand();
			break;
		case Constant.COPY:
			extraCommand=command.trim().toLowerCase().substring(Constant.COPYLENGTH);
			commandCOPY.excuteCommand(extraCommand);
			break;
		case Constant.MOVE:
			extraCommand=command.trim().toLowerCase().substring(Constant.MOVELENGTH);
			commandMOVE.excuteCommand(extraCommand);
			break;
		case Constant.EXIT:
			return true;
		default:
			information.informNoneCommand(firstKeyWord);
		}
		return false;
	}
}

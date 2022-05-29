package controller.commands;

import java.io.File;

import controller.commandExcution;
import model.DirectoryData;
import view.CommandResult;

public class DIR implements commandExcution {
	CommandResult commandResult;
	DirectoryData directoryData;
	File path;
	public DIR(CommandResult commandResult,DirectoryData directoryData) {
		this.commandResult=commandResult;
		this.directoryData=directoryData;
	}
	@Override
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		
	}
}

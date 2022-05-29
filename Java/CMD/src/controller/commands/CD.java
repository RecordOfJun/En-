package controller.commands;
import view.*;

import java.io.File;

import controller.commandExcution;
import model.*;
public class CD implements commandExcution {
	CommandResult commandResult;
	DirectoryData directoryData;
	File path;
	public CD(CommandResult commandResult,DirectoryData directoryData) {
		this.commandResult=commandResult;
		this.directoryData=directoryData;
	}
	@Override
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		/*
		if(keyWords.length==1) {
			synchronizeFile();
			CDBranch(keyWords[0]);
		}
		else{
			
		}
		*/
	}
	private void synchronizeFile() {
		path=new File(directoryData.getDirectory());
	}
	private void CDBranch(String firstKeyWord) {
		switch(firstKeyWord) {
			case "":
				commandResult.showDirectory(directoryData.getDirectory());
				break;
			case "..":
				moveToParent();
				break;
			case "\\":
				moveToRoot();
				break;
			case "..\\..":
				moveToParent();
				moveToParent();
				break;
				
		}
	}
	private boolean moveToParent() {
		String parentPath;
		if(path.getParentFile()!=null) {
			parentPath=path.getParentFile().getAbsolutePath();
			path=path.getParentFile();
		}
		else
			return true;
		directoryData.setDirectory(parentPath);
		return false;
	}
	private void moveToRoot() {
		boolean isRoot=false;
		while(!isRoot)
			isRoot=moveToParent();
	}
	private void moveToAbsolutePath() {
		
	}
}

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
		synchronizeFile();
		CDBranch(command);
	}
	private void synchronizeFile() {
		path=new File(directoryData.getDirectory());
	}
	private void CDBranch(String extraLine) {
		String extraCommand=extraLine.trim();
		switch(extraCommand) {
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
			default:
				moveToAbsolutePath(extraCommand);
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
	private void moveToAbsolutePath(String filePath) {
		path=new File(filePath);
		if(path.exists())
			directoryData.setDirectory(path.getAbsolutePath());
		else
			System.out.println("지정된 경로를 찾을 수 없습니다.");
			
	}
}

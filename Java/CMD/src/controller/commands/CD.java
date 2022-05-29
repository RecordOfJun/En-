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
		if(extraCommand.equals(""))
			commandResult.showDirectory(path.getAbsolutePath());
		if(extraCommand.contains(":"))
			moveToAbsolutePath(extraCommand);
		else
			moveToRelativePath(extraCommand);
		checkAndSetPath();
	}
	private void moveToAbsolutePath(String filePath) {
		path=new File(filePath);
			
	}
	private void moveToRelativePath(String filePath) {
		path=new File(path.getPath()+"\\"+filePath);
	}
	private void checkAndSetPath() {
		if(path.exists()) {
			if(!path.isDirectory()) {
				System.out.println("디렉터리 이름이 올바르지 않습니다.");
			}
			try {
				directoryData.setDirectory(path.getCanonicalPath());
			}
			catch(Exception e) {
				System.out.println("지정된 경로를 찾을 수 없습니다.");
				return;
			}
		}
		else
			System.out.println("지정된 경로를 찾을 수 없습니다.");
	}
}

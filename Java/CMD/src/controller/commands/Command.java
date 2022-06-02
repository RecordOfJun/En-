package controller.commands;

import java.io.File;

import model.DirectoryData;
import utility.Constant;
import view.CommandResult;

public class Command {//명령어 클래스들의 부모 클래스
	protected CommandResult commandResult;
	protected DirectoryData directoryData;
	protected File path;
	
	public Command(CommandResult commandResult,DirectoryData directoryData) {
		this.commandResult=commandResult;
		this.directoryData=directoryData;
	}
	protected void synchronizeFile() {//현재 위치 동기화
		path=new File(directoryData.getDirectory());
	}
	protected void movePath(String extraLine) {//파일 경로 이동
		String extraCommand=extraLine.trim();
		if(extraCommand.startsWith(Constant.BACKSLASH)){//경로 맨 앞에 '\'들어오면 드라이브로 이동
			extraCommand=Constant.ROOTDRIVE+extraCommand;
		}
		if(extraCommand.contains(Constant.COLONE))//절대경로 이동
			moveToAbsolutePath(extraCommand);
		else//상대경로 이동
			moveToRelativePath(extraCommand);
	}
	protected void moveToAbsolutePath(String filePath) {//절대경로 이동
		path=new File(filePath);
		path=new File(getPath(path));
			
	}
	protected void moveToRelativePath(String filePath) {//상대경로 이동
		path=new File(path.getPath()+Constant.BACKSLASH+filePath);
		path=new File(getPath(path));
	}
	protected String getPath(File file) {//경로 내의 ..처리해주기 위한 함수
		try {
			String canonicalPath=file.getCanonicalPath();
			return canonicalPath;
		}
		catch(Exception e) {
			return Constant.EMPTY;
		}
	}
}

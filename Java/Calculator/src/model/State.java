package model;

public class State {//셋다 모델이라고 보기엔 조금 애매함,컨트롤러에서 함수로 관리해야??
	private int lastType;
	private boolean isError;
	private boolean isLog;
	public State() {
		isError=false;
		isLog=false;
	}
	public int getLastType() {
		return lastType;
	}
	public void setLastType(int lastType) {
		this.lastType=lastType;
	}
	public void setIsError(boolean bool) {
		isError=bool;
	}
	public boolean getIsError() {
		return isError;
	}
	public void setIsLog(boolean bool) {
		isLog=bool;
	}
	public boolean getIsLog() {
		return isLog;
	}
}

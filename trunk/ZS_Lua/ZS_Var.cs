/*
    ZS_SCRIPT VARIABLE
    Copyright (C) 2011  Zephyr

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS_Lua_Test.ZS_Lua
{
    public enum VAR_TYPE
    {
        VBOOL,
        VINT,
        VSTRING,
        VFLOAT
    }

    public class ZS_Var
    {
        ZS_Var(String name, VAR_TYPE vtype)
        {
            m_name = name;
            m_type = vtype;
            switch (vtype)
            {
                case VAR_TYPE.VBOOL :
                    m_value = new System.Boolean();
                    break;

                case VAR_TYPE.VFLOAT :
                    m_value = new System.Double();
                    break;

                case VAR_TYPE.VINT :
                    m_value = new System.Int64();
                    break;

                case VAR_TYPE.VSTRING :
                    m_value = "";
                    break;
            }
        }

        ZS_Var(String name, VAR_TYPE vtype, Object value)
        {
            m_name = name;
            m_type = vtype;
            m_value = value;
        }

        public static ZS_Var NewBool(String name, Boolean value = false)
        {
            return new ZS_Var(name, VAR_TYPE.VBOOL, value);
        }

        public static ZS_Var NewInt(String name, Int64 value = 0)
        {
            return new ZS_Var(name, VAR_TYPE.VINT, value);
        }

        public static ZS_Var NewString(String name, String value = "")
        {
            return new ZS_Var(name, VAR_TYPE.VSTRING, value);
        }

        public static ZS_Var NewFloat(String name, Double value = 0.0)
        {
            return new ZS_Var(name, VAR_TYPE.VFLOAT, value);
        }

        private String m_name;
        private VAR_TYPE m_type;
        private Object m_value;
        private bool m_constant;

        public String Name
        {
            get
            {
                return m_name;
            }
        }

        public VAR_TYPE Type
        {
            get
            {
                return m_type;
            }
        }

        public bool Constant
        {
            get
            {
                return m_constant;
            }

            set
            {
                m_constant = value;
            }
        }

        public Object Value
        {
            get
            {
                return m_value;
            }

            set
            {
                if (!m_constant)
                {
                    m_value = value;
                }

                /* TODO (Zephyr) : Maybe add somekind of exception when the variable is constant */
            }
        }
    }
}

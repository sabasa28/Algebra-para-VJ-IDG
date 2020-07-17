﻿using CustomMath;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMath
{
    public struct MatrixRecargada
    {
        public float m00;
        public float m33;
        public float m23;
        public float m13;
        public float m03;
        public float m32;
        public float m22;
        public float m02;
        public float m12;
        public float m21;
        public float m11;
        public float m01;
        public float m30;
        public float m20;
        public float m10;
        public float m31;

        public MatrixRecargada(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            m00 = column0.x;
            m01 = column1.x;
            m02 = column2.x;
            m03 = column3.x;
            m10 = column0.y;
            m11 = column1.y;
            m12 = column2.y;
            m13 = column3.y;
            m20 = column0.z;
            m21 = column1.z;
            m22 = column2.z;
            m23 = column3.z;
            m30 = column0.w;
            m31 = column1.w;
            m32 = column2.w;
            m33 = column3.w;
        }

        public static MatrixRecargada zero {
            get
            {
                return new MatrixRecargada(
                    new Vector4(0f, 0f, 0f, 0f),
                    new Vector4(0f, 0f, 0f, 0f),
                    new Vector4(0f, 0f, 0f, 0f),
                    new Vector4(0f, 0f, 0f, 0f)
                    );
            }
        }
        //
        // Resumen:
        //     Returns the identity matrix (Read Only).
        public static MatrixRecargada identity
        {
            get
            {
                return new MatrixRecargada(
                    new Vector4(1f, 0f, 0f, 0f),
                    new Vector4(0f, 1f, 0f, 0f),
                    new Vector4(0f, 0f, 1f, 0f),
                    new Vector4(0f, 0f, 0f, 1f));
            }
        }

        public static MatrixRecargada Rotate(Quarentenion q)
        {
            MatrixRecargada mRot = identity;
            mRot.m00 = 1 - 2.0f * (q.y * q.y) - 2.0f * (q.z * q.z);
            mRot.m01 = 2.0f * (q.x * q.y) - 2.0f * (q.z * q.w);
            mRot.m02 = 2.0f * (q.x * q.z) + 2.0f * (q.y * q.w);
            mRot.m10 = 2.0f * (q.x * q.y) + 2.0f * (q.z * q.w);
            mRot.m11 = 1 - 2.0f * (q.x * q.x) - 2.0f * (q.z * q.z);
            mRot.m12 = 2.0f * (q.y * q.z) - 2.0f * (q.x * q.w);
            mRot.m20 = 2.0f * (q.x * q.z) - 2.0f * (q.y * q.w);
            mRot.m21 = 2.0f * (q.y * q.z) + 2.0f * (q.x * q.w);
            mRot.m22 = 1 - 2.0f * (q.x * q.x) - 2.0f * (q.y * q.y);

            return mRot;
        }
        //
        // Resumen:
        //     Creates a scaling matrix.
        //
        // Parámetros:
        //   vector:
        public static MatrixRecargada Scale(Vec3 vector)
        {
            MatrixRecargada mScale = zero;

            mScale.m00 = vector.x;
            mScale.m11 = vector.y;
            mScale.m22 = vector.z;
            mScale.m33 = 1.0f;

            return mScale;
        }
        //
        // Resumen:
        //     Creates a translation matrix.
        //
        // Parámetros:
        //   vector:
        public static MatrixRecargada Translate(Vec3 vector)
        {
            MatrixRecargada mTrans = identity;
            mTrans.m03 = vector.x;
            mTrans.m13 = vector.y;
            mTrans.m23 = vector.z;
            mTrans.m33 = 1.0f;

            return mTrans;
        }
        public static MatrixRecargada TRS(Vec3 pos, Quarentenion q, Vec3 s)
        {
            MatrixRecargada matTrans = Translate(pos);
            MatrixRecargada matRot = Rotate(q);
            MatrixRecargada matScale = Scale(s);
            MatrixRecargada trs = matTrans * matRot * matScale;
            return trs;
        }
        public override string ToString()
        {
            return (
            "m00  " + m00 +
            "  m01  " + m01 +
            "  m02  " + m02 +
            "  m03  " + m03 +
            "\nm10  " + m10 +
            "  m11  " + m11 +
            "  m12  " + m12 +
            "  m13  " + m13 +
            "\nm20  " + m20 +
            "  m21  " + m21 +
            "  m22  " + m22 +
            "  m23  " + m23 +
            "\nm30  " + m30 +
            "  m31  " + m31 +
            "  m32  " + m32 +
            "  m33  " + m33);
        }
        public static Vector4 operator *(MatrixRecargada lhs, Vector4 vector)
        {
            Vector4 newVec4 = Vector4.zero;
            newVec4.x = (lhs.m00 * vector.x) + (lhs.m01 * vector.y) + (lhs.m02 * vector.z) + (lhs.m03 * vector.w);
            newVec4.y = (lhs.m10 * vector.x) + (lhs.m11 * vector.y) + (lhs.m12 * vector.z) + (lhs.m13 * vector.w);
            newVec4.z = (lhs.m20 * vector.x) + (lhs.m21 * vector.y) + (lhs.m22 * vector.z) + (lhs.m23 * vector.w);
            newVec4.w = (lhs.m30 * vector.x) + (lhs.m31 * vector.y) + (lhs.m32 * vector.z) + (lhs.m33 * vector.w);
            return newVec4;
        }
        public static MatrixRecargada operator *(MatrixRecargada lhs, MatrixRecargada rhs)
        {
            MatrixRecargada matXMat = zero;
            matXMat.m00 = (lhs.m00 * rhs.m00) + (lhs.m01 * rhs.m10) + (lhs.m02 * rhs.m20) + (lhs.m03 * rhs.m30);
            matXMat.m01 = (lhs.m00 * rhs.m01) + (lhs.m01 * rhs.m11) + (lhs.m02 * rhs.m21) + (lhs.m03 * rhs.m31);
            matXMat.m02 = (lhs.m00 * rhs.m02) + (lhs.m01 * rhs.m12) + (lhs.m02 * rhs.m22) + (lhs.m03 * rhs.m32);
            matXMat.m03 = (lhs.m00 * rhs.m03) + (lhs.m01 * rhs.m13) + (lhs.m02 * rhs.m23) + (lhs.m03 * rhs.m33);

            matXMat.m10 = (lhs.m10 * rhs.m00) + (lhs.m11 * rhs.m10) + (lhs.m12 * rhs.m20) + (lhs.m13 * rhs.m30);
            matXMat.m11 = (lhs.m10 * rhs.m01) + (lhs.m11 * rhs.m11) + (lhs.m12 * rhs.m21) + (lhs.m13 * rhs.m31);
            matXMat.m12 = (lhs.m10 * rhs.m02) + (lhs.m11 * rhs.m12) + (lhs.m12 * rhs.m22) + (lhs.m13 * rhs.m32);
            matXMat.m13 = (lhs.m10 * rhs.m03) + (lhs.m11 * rhs.m13) + (lhs.m12 * rhs.m23) + (lhs.m13 * rhs.m33);
            
            matXMat.m20 = (lhs.m20 * rhs.m00) + (lhs.m21 * rhs.m10) + (lhs.m22 * rhs.m20) + (lhs.m23 * rhs.m30);
            matXMat.m21 = (lhs.m20 * rhs.m01) + (lhs.m21 * rhs.m11) + (lhs.m22 * rhs.m21) + (lhs.m23 * rhs.m31);
            matXMat.m22 = (lhs.m20 * rhs.m02) + (lhs.m21 * rhs.m12) + (lhs.m22 * rhs.m22) + (lhs.m23 * rhs.m32);
            matXMat.m23 = (lhs.m20 * rhs.m03) + (lhs.m21 * rhs.m13) + (lhs.m22 * rhs.m23) + (lhs.m23 * rhs.m33);
            
            matXMat.m30 = (lhs.m30 * rhs.m00) + (lhs.m31 * rhs.m10) + (lhs.m32 * rhs.m20) + (lhs.m33 * rhs.m30);
            matXMat.m31 = (lhs.m30 * rhs.m01) + (lhs.m31 * rhs.m11) + (lhs.m32 * rhs.m21) + (lhs.m33 * rhs.m31);
            matXMat.m32 = (lhs.m30 * rhs.m02) + (lhs.m31 * rhs.m12) + (lhs.m32 * rhs.m22) + (lhs.m33 * rhs.m32);
            matXMat.m33 = (lhs.m30 * rhs.m03) + (lhs.m31 * rhs.m13) + (lhs.m32 * rhs.m23) + (lhs.m33 * rhs.m33);
            return matXMat;
        }
        public static bool operator ==(MatrixRecargada lhs, MatrixRecargada rhs)
        {
            return (lhs.m00 == rhs.m00 && lhs.m01 == rhs.m01 && lhs.m02 == rhs.m02 && lhs.m03 == rhs.m03 &&
                lhs.m10 == rhs.m10 && lhs.m11 == rhs.m11 && lhs.m12 == rhs.m12 && lhs.m13 == rhs.m13 &&
                lhs.m20 == rhs.m20 && lhs.m21 == rhs.m21 && lhs.m22 == rhs.m22 && lhs.m23 == rhs.m23 &&
                lhs.m30 == rhs.m30 && lhs.m31 == rhs.m31 && lhs.m32 == rhs.m32 && lhs.m33 == rhs.m33);
        }
        public static bool operator !=(MatrixRecargada lhs, MatrixRecargada rhs)
        {
            return !(lhs==rhs);
        }
        public static implicit operator Matrix4x4(MatrixRecargada q)
        {
            return new Matrix4x4(
                new Vector4(
                q.m00,
                q.m10,
                q.m20,
                q.m30),
                new Vector4(
                q.m01,
                q.m11,
                q.m21,
                q.m31),
                new Vector4(
                q.m02,
                q.m12,
                q.m22,
                q.m32),
                new Vector4(
                q.m03,
                q.m13,
                q.m23,
                q.m33)
                );
        }
    }
}
